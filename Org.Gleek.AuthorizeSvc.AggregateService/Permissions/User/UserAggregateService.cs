using Com.GleekFramework.ContractSdk;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Service;

namespace Org.Gleek.AuthorizeSvc.AggregateService
{
    /// <summary>
    /// 用户聚合服务
    /// </summary>
    public class UserAggregateService : BaseAggregateService
    {
        /// <summary>
        /// 用户领域服务
        /// </summary>
        public UserService UserService { get; set; }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public async Task<ContractResult<JwtTokenModel>> ValidateTokenAsync(string token)
        {
            return await UserService.ValidateTokenAsync(token);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public async Task<ContractResult<string>> LoginAsync(string userName, string password)
        {
            return await UserService.LoginAsync(userName, password);
        }
    }
}