using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Com.GleekFramework.RedisSdk;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Org.Gleek.AuthorizeSvc.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Org.Gleek.AuthorizeSvc.Service
{
    /// <summary>
    /// 用户授权授权服务
    /// </summary>
    public class UserAuthService : BaseService
    {
        /// <summary>
        /// Token的有效期
        /// </summary>
        private const int ExpireSeconds = 7200;

        /// <summary>
        /// Redis字符串仓储类
        /// </summary>
        public RedisStringRepository RedisStringRepository { get; set; }

        /// <summary>
        /// 生成加密Key
        /// </summary>
        private const string SecretKey = "M02cnQ51Ji97vwT4MO5nvlqvx68BhdEz";

        /// <summary>
        /// 获取授权的用户Id
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public async Task<long?> GetUserIdAsync(string fieldName)
        {
            if (fieldName.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                var cacheKey = RedisCacheConstant.GetUserIdKey(fieldName);
                return await RedisStringRepository.GetAsync<long?>(cacheKey);
            }
        }

        /// <summary>
        /// 获取授权的用户Id
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="expireSeconds">过期时间(单位：秒)</param>
        /// <returns></returns>
        public async Task<bool> SetUserIdAsync(string fieldName, long userId, int expireSeconds = 7200)
        {
            if (fieldName.IsNullOrEmpty())
            {
                return false;
            }
            else
            {
                var cacheKey = RedisCacheConstant.GetUserIdKey(fieldName);
                return await RedisStringRepository.SetAsync(cacheKey, userId, expireSeconds);
            }
        }

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        public async Task<UserTokenModel> GenTokenAsync(UserAuthModel userInfo)
        {
            var claims = new List<Claim>();
            var propertyInfoList = userInfo.GetPropertyInfoList();
            if (!propertyInfoList.IsNotNull())
            {
                return null;
            }

            foreach (var propertyInfo in propertyInfoList)
            {
                var propertyName = propertyInfo.Name;//属性名称
                var propertyValue = propertyInfo.GetPropertyValue<string>(propertyName);//属性值
                var customAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                if (customAttribute != null)
                {
                    //绑定自定义属性名称
                    propertyName = customAttribute.PropertyName;
                }
                claims.Add(new Claim(propertyName, propertyValue));
            }

            var symmetricKey = Encoding.UTF8.GetBytes(SecretKey);
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var symmetricSecurityKey = new SymmetricSecurityKey(symmetricKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(ExpireSeconds),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, algorithm)
            };

            var refreshToken = Guid.NewGuid().ToString().ToLower();//生成刷新令牌
            await SetUserIdAsync(refreshToken, userInfo.Id, ExpireSeconds);//设置刷新Token的缓存

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);//生成TOKEN字符串
            await SetUserIdAsync(accessToken.EncryptMd5(), userInfo.Id, ExpireSeconds);//设置登录Token的缓存
            return await Task.FromResult(new UserTokenModel()
            {
                UserId = userInfo.Id,
                Token = accessToken,
                RefreshToken = refreshToken,
                ExpireSeconds = ExpireSeconds
            });
        }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public async Task<ContractResult<UserAuthModel>> ValidateAsync(string token)
        {
            var result = new ContractResult<UserAuthModel>();
            try
            {
                var userId = await GetUserIdAsync(token.EncryptMd5());
                if (!userId.HasValue)
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var symmetricKey = Encoding.UTF8.GetBytes(SecretKey);
                var tokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero, //确保即时的token过期验证
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                };

                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (claimsPrincipal == null)
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }

                var userInfo = new UserAuthModel();//用户信息
                var claims = claimsPrincipal.Claims;
                var propertyInfoList = typeof(UserAuthModel).GetPropertyInfoList();
                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyName = propertyInfo.Name;//属性名称
                    var customAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                    if (customAttribute != null)
                    {
                        var propertyTypeName = customAttribute.PropertyName;
                        var propertyValue = claims.FirstOrDefault(e => e.Type == propertyTypeName)?.Value;//属性值
                        userInfo.SetPropertyValue(propertyName, propertyValue);//设置属性值
                    }
                    else
                    {
                        var propertyValue = claims.FirstOrDefault(e => e.Type == propertyName)?.Value;//属性值
                        userInfo.SetPropertyValue(propertyName, propertyValue);//设置属性值
                    }
                }

                if (userInfo.Id <= 0)
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }
                result.SetSuceccful(userInfo);
            }
            catch (Exception)
            {
                result.SetError(MessageCode.TOKEN_INVALID);
            }
            return await Task.FromResult(result);
        }
    }
}