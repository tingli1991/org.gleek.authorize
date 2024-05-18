using Com.GleekFramework.AttributeSdk;
using Com.GleekFramework.ContractSdk;
using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Models.Params;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    [Route("api/login")]
    public class LoginController : BaseController
    {
        /// <summary>
        /// 登录聚合服务
        /// </summary>
        public LoginAggregateService LoginAggregateService { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ContractResult<UserTokenModel>> LoginAsync(LoginParam param)
        {
            return await LoginAggregateService.LoginAsync(param.UserName, param.Password);
        }
    }
}