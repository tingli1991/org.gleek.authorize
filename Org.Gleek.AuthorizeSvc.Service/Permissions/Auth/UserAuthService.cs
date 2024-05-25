using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Com.GleekFramework.NLogSdk;
using Com.GleekFramework.RedisSdk;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Org.Gleek.AuthorizeSvc.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace Org.Gleek.AuthorizeSvc.Service
{
    /// <summary>
    /// 用户授权授权服务
    /// </summary>
    public class UserAuthService : BaseService
    {
        /// <summary>
        /// 日志服务
        /// </summary>
        public NLogService NLogService { get; set; }

        /// <summary>
        /// Redis分布式锁仓储
        /// </summary>
        public RedisLockRepository RedisLockRepository { get; set; }

        /// <summary>
        /// Redis字符串仓储类
        /// </summary>
        public RedisStringRepository RedisStringRepository { get; set; }

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        public async Task<ContractResult<UserTokenModel>> GenAccessTokenAsync(UserAuthModel userInfo)
        {
            var result = new ContractResult<UserTokenModel>();
            var accessTokenLockKey = RedisCacheConstant.GetAccessTokenLockKey(userInfo.Id);
            using var lockClient = await RedisLockRepository.LockUpAsync(accessTokenLockKey);
            if (lockClient == null)
            {
                result.SetError(MessageCode.FREQUENT_OPERATION);
                return result;
            }

            var userId = userInfo.Id;//用户Id
            var cacheAccessToken = await GetAccessTokenAsync(userId);//访问令牌
            var (userAuthInfo, expireTime) = await ParseJwtSecurityTokenAsync(cacheAccessToken);//用户信息
            if (userAuthInfo != null && expireTime.HasValue && expireTime.Value.Subtract(DateTime.Now.ToCstTime()).Seconds > 5)
            {
                return result.SetSuceccful(new UserTokenModel()
                {
                    UserId = userId,
                    AccessToken = cacheAccessToken,
                    ExpireTime = expireTime.Value,
                    ExpiresIn = UserAuthConstant.EXPIRE_SECONDS,
                    RefreshToken = await GetRefreshTokenAsync(cacheAccessToken)
                });
            }
            else
            {
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Claims = await ConvertClaimsAsync(userInfo),
                    SigningCredentials = UserAuthConstant.SigningCredentials,
                    Expires = DateTime.UtcNow.AddSeconds(UserAuthConstant.EXPIRE_SECONDS),//过期时间
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                var refreshToken = await SetUserAccessTokenAndRefreshTokenAsync(userId, accessToken, UserAuthConstant.EXPIRE_SECONDS);
                if (refreshToken.IsNullOrEmpty() || accessToken.IsNullOrEmpty())
                {
                    return result;
                }

                var expiresTime = tokenDescriptor.Expires.Value.ToLocalTime();//转换为本地时间
                return result.SetSuceccful(new UserTokenModel()
                {
                    UserId = userId,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = UserAuthConstant.EXPIRE_SECONDS,
                    ExpireTime = new DateTime(expiresTime.Year, expiresTime.Month, expiresTime.Day, expiresTime.Hour, expiresTime.Minute, expiresTime.Second)
                });
            }
        }

        /// <summary>
        /// 验证令牌是否过期
        /// </summary>
        /// <param name="accessToken">TOKEN</param>
        /// <returns></returns>
        public async Task<ContractResult<UserAuthModel>> ValidateAccessTokenAsync(string accessToken)
        {
            var result = new ContractResult<UserAuthModel>();
            try
            {
                var (userAuthInfo, expireTime) = await ParseJwtSecurityTokenAsync(accessToken);
                if (userAuthInfo == null || !expireTime.HasValue)
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }

                //验证令牌缓存是否有效
                var cacheAccessToken = await GetAccessTokenAsync(userAuthInfo.Id);
                if (cacheAccessToken.IsNullOrEmpty() || !accessToken.Equals(cacheAccessToken))
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }

                //验证令牌
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero, //确保即时的TOKEN过期验证
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = UserAuthConstant.SymmetricSecurityKey,
                };
                tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken validatedToken);
                result.SetSuceccful(userAuthInfo);//设置返回结果为验证成功
            }
            catch (SecurityTokenException)
            {
                //令牌验证失败异常
                result.SetError(MessageCode.TOKEN_INVALID);
            }
            catch (Exception ex)
            {
                result.SetError(MessageCode.TOKEN_INVALID);
                NLogService.Error($"【Token验证】请求参数：{accessToken}，发生未经处理的异常：{ex}");
            }
            return result;
        }

        /// <summary>
        /// 获取访问令牌
        /// </summary>
        /// <param name="userId">字段名称</param>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync(long userId)
        {
            if (userId <= 0)
            {
                return null;
            }

            var cacheKey = RedisCacheConstant.GetAccessTokenKey(userId);
            return await RedisStringRepository.GetAsync<string>(cacheKey);
        }

        /// <summary>
        /// 获取刷新令牌
        /// </summary>
        /// <param name="accessToken">刷新令牌</param>
        /// <returns></returns>
        public async Task<string> GetRefreshTokenAsync(string accessToken)
        {
            if (accessToken.IsNullOrEmpty())
            {
                return null;
            }

            var cacheKey = RedisCacheConstant.GetRefreshTokenKey(accessToken);
            return await RedisStringRepository.GetAsync<string>(cacheKey);
        }

        /// <summary>
        /// 删除刷新令牌
        /// </summary>
        /// <param name="accessToken">刷新令牌</param>
        /// <returns></returns>
        public async Task<bool> DeleteRefreshTokenAsync(string accessToken)
        {
            if (accessToken.IsNullOrEmpty())
            {
                return false;
            }

            var cacheKey = RedisCacheConstant.GetRefreshTokenKey(accessToken);
            return await RedisStringRepository.DeleteAsync(cacheKey);
        }

        /// <summary>
        /// 转换用户授权模型
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <returns></returns>
        public async Task<(UserAuthModel UserInfo, DateTime? ExpireTime)> ParseJwtSecurityTokenAsync(string accessToken)
        {
            if (accessToken.IsNullOrEmpty())
            {
                return (null, null);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadJwtToken(accessToken);
            return await ParseJwtSecurityTokenAsync(jsonToken);
        }

        /// <summary>
        /// 转换用户授权模型
        /// </summary>
        /// <param name="securityToken">TOKEN信息</param>
        /// <returns></returns>
        private async Task<(UserAuthModel UserAuthInfo, DateTime? ExpireTime)> ParseJwtSecurityTokenAsync(SecurityToken securityToken)
        {
            if (securityToken == null)
            {
                return (null, null);
            }

            var jwtSecurityToken = (JwtSecurityToken)securityToken;
            var jsonValue = JsonConvert.SerializeObject(jwtSecurityToken.Payload);
            var userAuthInfo = JsonConvert.DeserializeObject<UserAuthModel>(jsonValue);

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiryDate = epoch.AddSeconds(jwtSecurityToken.Payload.Exp ?? 0);
            var expireTime = expiryDate.ToLocalTime();
            return await Task.FromResult((userAuthInfo, expireTime));
        }

        /// <summary>
        /// 转换Token存储的数据模型字典
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        private async Task<Dictionary<string, object>> ConvertClaimsAsync(UserAuthModel userInfo)
        {
            var claims = new Dictionary<string, object>();
            var propertyInfoList = userInfo.GetPropertyInfoList();
            if (!propertyInfoList.IsNotNull())
            {
                return claims;
            }

            foreach (var propertyInfo in propertyInfoList)
            {
                var propertyName = propertyInfo.Name;//属性名称
                var propertyValue = userInfo.GetPropertyValue(propertyName);//属性值
                var customAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                if (customAttribute != null)
                {
                    //绑定自定义属性名称
                    propertyName = customAttribute.PropertyName;
                }
                claims.Add(propertyName, propertyValue);
            }
            return await Task.FromResult(claims);
        }

        /// <summary>
        /// 设置用户的访问令牌和刷新令牌缓存
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="accessToken">访问令牌</param>
        /// <param name="expireSeconds">过期时间(单位：秒)</param>
        /// <returns>刷新令牌</returns>
        private async Task<string> SetUserAccessTokenAndRefreshTokenAsync(long userId, string accessToken, int expireSeconds = 7200)
        {
            if (userId <= 0 || accessToken.IsNullOrEmpty())
            {
                return "";
            }

            // 设置访问令牌缓存
            var accessTokenCacheKey = RedisCacheConstant.GetAccessTokenKey(userId);
            var isSuccess = await RedisStringRepository.SetAsync(accessTokenCacheKey, accessToken, expireSeconds);
            if (!isSuccess)
            {
                return "";
            }

            //设置刷新令牌缓存
            var refreshToken = $"{Guid.NewGuid():N}";//刷新令牌
            var refreshTokenCacheKey = RedisCacheConstant.GetRefreshTokenKey(accessToken);
            var refreshTokenExpireSeconds = RedisStringRepository.GetExpireSeconds(3600 * 24 * 7, 3600 * 24 * 15);
            isSuccess = await RedisStringRepository.SetAsync(refreshTokenCacheKey, refreshToken, refreshTokenExpireSeconds);
            if (!isSuccess)
            {
                return "";
            }
            return refreshToken;
        }
    }
}