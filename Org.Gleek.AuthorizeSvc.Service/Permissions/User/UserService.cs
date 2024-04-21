using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Repository;

namespace Org.Gleek.AuthorizeSvc.Service
{
    /// <summary>
    /// 用户领域服务
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public UserRepository UserRepository { get; set; }

        /// <summary>
        /// Token服务
        /// </summary>
        public JwtTokenService JwtTokenService { get; set; }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public async Task<ContractResult<JwtTokenModel>> ValidateTokenAsync(string token)
        {
            return await JwtTokenService.ValidateTokenAsync(token);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public async Task<ContractResult<string>> LoginAsync(string userName, string password)
        {
            var result = new ContractResult<string>();
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return result.SetError(MessageCode.USER_NAME_OR_PASSWORD_REQUIRED);
            }

            var userInfo = await UserRepository.GetUserAsync(userName);
            if (userInfo == null)
            {
                return result.SetError(MessageCode.UNKNOWN_USER);
            }

            if (!userInfo.Password.Equals(password))
            {
                return result.SetError(MessageCode.USER_NAME_OR_PASSWORD_ERROR);
            }

            var jwtTokenInfo = userInfo.Map<User, JwtTokenModel>();
            var token = await JwtTokenService.GenerateTokenAsync(jwtTokenInfo);
            return result.SetSuceccful(token);
        }
    }
}