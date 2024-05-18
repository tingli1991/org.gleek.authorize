using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Service;

namespace Org.Gleek.AuthorizeSvc.AggregateService
{
    /// <summary>
    /// 授权聚合服务
    /// </summary>
    public class LoginAggregateService : BaseAggregateService
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
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public async Task<ContractResult<UserTokenModel>> LoginAsync(string userName, string password)
        {
            var result = new ContractResult<UserTokenModel>();
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return result.SetError(MessageCode.USER_NAME_OR_PASSWORD_REQUIRED);
            }

            var userInfo = await UserService.GetUserAsync(userName);
            if (userInfo == null)
            {
                return result.SetError(MessageCode.UNKNOWN_USER);
            }

            if (!userInfo.Password.Equals(password))
            {
                return result.SetError(MessageCode.USER_NAME_OR_PASSWORD_ERROR);
            }

            var userAuthInfo = userInfo.Map<User, UserAuthModel>();
            var userTokenInfo = await UserAuthService.GenTokenAsync(userAuthInfo);
            if (userTokenInfo == null)
            {
                return result.SetError(MessageCode.UNKNOWN_USER);
            }
            return result.SetSuceccful(userTokenInfo);
        }
    }
}