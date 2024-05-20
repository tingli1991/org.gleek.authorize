using Com.GleekFramework.ContractSdk;
using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Attributes;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Models.Models;
using Org.Gleek.AuthorizeSvc.Models.Params;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// 授权控制器
    /// </summary>
    [Route("api/auth")]
    public class AuthController : UserAuthController
    {
        /// <summary>
        /// 用户聚合服务
        /// </summary>
        public UserAggregateService UserAggregateService { get; set; }

        /// <summary>
        /// 授权聚合服务
        /// </summary>
        public AuthAggregateService AuthAggregateService { get; set; }

        /// <summary>
        /// 验证TOKEN
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [HttpPost("validate-token")]
        public async Task<ContractResult<UserAuthModel>> ValidateTokenAsync(ValidateTokenParam param)
        {
            return await AuthAggregateService.ValidateTokenAsync(param.Token);
        }

        /// <summary>
        /// 刷新TOKEN
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpPost("refresh-token")]
        public async Task<ContractResult<UserTokenModel>> RefreshTokenAsync(RefreshTokenParam param)
        {
            return await AuthAggregateService.RefreshTokenAsync(param.RefreshToken);
        }

        /// <summary>
        /// 获取登录授权信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpGet("get-user-auth/{user_id}")]
        public async Task<UserAuthModel> GetUserAuthAsync([FromRoute(Name = "user_id")] long userId)
        {
            return await UserAggregateService.GetUserAuthAsync(userId);
        }
    }
}