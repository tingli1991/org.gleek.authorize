using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Service;

namespace Org.Gleek.AuthorizeSvc.AggregateService
{
    /// <summary>
    /// 登录聚合服务
    /// </summary>
    public class AuthAggregateService : BaseAggregateService
    {
        /// <summary>
        /// 用户服务
        /// </summary>
        public UserService UserService { get; set; }

        /// <summary>
        /// Token服务
        /// </summary>
        public UserAuthService UserAuthService { get; set; }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public async Task<ContractResult<UserAuthModel>> ValidateTokenAsync(string token)
        {
            return await UserAuthService.ValidateAsync(token);
        }

        /// <summary>
        /// 刷新TOKEN
        /// </summary>
        /// <param name="refreshToken">刷新TOKEN</param>
        /// <returns></returns>
        public async Task<ContractResult<UserTokenModel>> RefreshTokenAsync(string refreshToken)
        {
            var result = new ContractResult<UserTokenModel>();
            var userId = await UserAuthService.GetUserIdAsync(refreshToken);
            if (!userId.HasValue)
            {
                result.SetError(MessageCode.TOKEN_INVALID);
                return result;
            }

            var userInfo = await UserService.GetUserAsync(userId.Value);
            if (userInfo == null)
            {
                return result.SetError(MessageCode.UNKNOWN_USER);
            }

            var userAuthInfo = userInfo.Map<User, UserAuthModel>();
            var newUserAuthInfo = await UserAuthService.GenTokenAsync(userAuthInfo); //重新生成新的访问令牌
            return result.SetSuceccful(newUserAuthInfo);// 返回新的令牌模型
        }
    }
}