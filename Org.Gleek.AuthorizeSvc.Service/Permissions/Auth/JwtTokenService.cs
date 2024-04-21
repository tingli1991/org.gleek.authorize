using Com.GleekFramework.ContractSdk;
using Microsoft.IdentityModel.Tokens;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Org.Gleek.AuthorizeSvc.Service
{
    /// <summary>
    /// JWT授权服务
    /// </summary>
    public class JwtTokenService : BaseService
    {
        /// <summary>
        /// Token的有效期
        /// </summary>
        private const double ExpireSeconds = 7200;

        /// <summary>
        /// 生成加密Key
        /// </summary>
        private const string SecretKey = "M02cnQ51Ji97vwT4MO5nvlqvx68BhdEz";

        /// <summary>
        /// 生成登录的Token信息
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns></returns>
        public async Task<string> GenerateTokenAsync(JwtTokenModel userInfo)
        {
            var claims = new List<Claim>()
            {
                new("user_id", $"{userInfo.Id}"),
                new("avatar", $"{userInfo.Avatar}"),
                new("gender", $"{userInfo.Gender}"),
                new("is_admin", $"{userInfo.IsAdmin}"),
                new("user_name", $"{userInfo.UserName}"),
                new("nick_name", $"{userInfo.NickName}"),
                new("business_card", $"{userInfo.BusinessCard}"),
                new("register_time", $"{userInfo.RegisterTime}"),
                new("last_login_time", $"{userInfo.LastLoginTime}"),
                new("last_logout_time", $"{userInfo.LastLogoutTime}"),
            };

            var symmetricKey = Encoding.ASCII.GetBytes(SecretKey);
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var symmetricSecurityKey = new SymmetricSecurityKey(symmetricKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(ExpireSeconds),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, algorithm)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public async Task<ContractResult<JwtTokenModel>> ValidateTokenAsync(string token)
        {
            var result = new ContractResult<JwtTokenModel>();
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var symmetricKey = Encoding.ASCII.GetBytes(SecretKey);
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

                var claims = claimsPrincipal.Claims;
                var isSuccess = long.TryParse(claims.FirstOrDefault(e => e.Type == "user_id")?.Value ?? "0", out long userId);
                if (!isSuccess)
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return result;
                }


                result.SetSuceccful(new JwtTokenModel()
                {
                    Id = userId,
                    Avatar = claims.FirstOrDefault(e => e.Type == "avatar")?.Value ?? "",
                    Gender = Enum.Parse<Gender>(claims.FirstOrDefault(e => e.Type == "gender")?.Value ?? "30"),
                    IsAdmin = bool.Parse(claims.FirstOrDefault(e => e.Type == "is_admin")?.Value ?? "false"),
                    UserName = claims.FirstOrDefault(e => e.Type == "user_name")?.Value ?? "",
                    NickName = claims.FirstOrDefault(e => e.Type == "nick_name")?.Value ?? "",
                    BusinessCard = claims.FirstOrDefault(e => e.Type == "business_card")?.Value ?? "",
                    RegisterTime = DateTime.Parse(claims.FirstOrDefault(e => e.Type == "register_time")?.Value ?? "0001/1/1 0:00:00"),
                    LastLoginTime = DateTime.Parse(claims.FirstOrDefault(e => e.Type == "last_login_time")?.Value ?? "0001/1/1 0:00:00"),
                    LastLogoutTime = DateTime.Parse(claims.FirstOrDefault(e => e.Type == "last_logout_time")?.Value ?? "0001/1/1 0:00:00"),
                });
            }
            catch (Exception)
            {
                result.SetError(MessageCode.TOKEN_INVALID);
            }
            return await Task.FromResult(result);
        }
    }
}