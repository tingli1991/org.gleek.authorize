using Com.GleekFramework.AttributeSdk;
using Com.GleekFramework.ContractSdk;
using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Models.Params;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("user")]
    public class UserController : BaseController
    {
        /// <summary>
        /// 用户聚合服务
        /// </summary>
        public UserAggregateService UserAggregateService { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "login")]
        public async Task<ContractResult<string>> LoginAsync(LoginParam param)
        {
            return await UserAggregateService.LoginAsync(param.UserName, param.Password);
        }

        /// <summary>
        /// 验证Token信息
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        [HttpGet(Name = "validate-token")]
        public async Task<ContractResult<JwtTokenModel>> ValidateTokenAsync(string token)
        {
            return await UserAggregateService.ValidateTokenAsync(token);
        }
    }
}