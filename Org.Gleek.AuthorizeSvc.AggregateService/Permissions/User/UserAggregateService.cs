using Org.Gleek.AuthorizeSvc.Entitys;
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
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(long userId)
        {
            return await UserService.GetUserAsync(userId);
        }

        /// <summary>
        /// 获取登录授权参数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<UserAuthModel> GetUserAuthAsync(long userId)
        {
            return await UserService.GetUserAuthAsync(userId);
        }
    }
}