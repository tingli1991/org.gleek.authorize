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
        /// 授权聚合服务
        /// </summary>
        public AuthAggregateService AuthAggregateService { get; set; }

        /// <summary>
        /// 获取登录授权信息
        /// </summary>
        /// <returns></returns>
        [UserAuth()]
        [HttpGet("get-user-auth")]
        public async Task<ContractResult<UserAuthModel>> GetUserAuthAsync()
        {
            return await AuthAggregateService.GetUserAuthAsync(AccessToken);
        }

        /// <summary>
        /// 验证访问令牌
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpPost("validate-access-token")]
        public async Task<ContractResult<UserAuthModel>> ValidateAccessTokenAsync(ValidateTokenParam param)
        {
            return await AuthAggregateService.ValidateAccessTokenAsync(param.Token);
        }

        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpPost("refresh-access-token")]
        public async Task<ContractResult<UserTokenModel>> RefreshAccessTokenAsync(RefreshTokenParam param)
        {
            return await AuthAggregateService.RefreshAccessTokenAsync(UserInfo.Id, param.RefreshToken, AccessToken);
        }
    }
}