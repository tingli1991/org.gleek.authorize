using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Attributes;
using Org.Gleek.AuthorizeSvc.Entitys;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/user")]
    public class UserController : UserAuthController
    {
        /// <summary>
        /// 用户聚合服务
        /// </summary>
        public UserAggregateService UserAggregateService { get; set; }

        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="userId">用户名称</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpGet("get-user-detail/{user_id}")]
        public async Task<User> GetUserAsync([FromRoute(Name = "user_id")] long userId)
        {
            return await UserAggregateService.GetUserAsync(userId);
        }
    }
}