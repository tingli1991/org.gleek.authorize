using Com.GleekFramework.AttributeSdk;
using Com.GleekFramework.ContractSdk;
using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Models.Params;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// �û�������
    /// </summary>
    [Route("user")]
    public class UserController : BaseController
    {
        /// <summary>
        /// �û��ۺϷ���
        /// </summary>
        public UserAggregateService UserAggregateService { get; set; }

        /// <summary>
        /// ��¼
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "login")]
        public async Task<ContractResult<string>> LoginAsync(LoginParam param)
        {
            return await UserAggregateService.LoginAsync(param.UserName, param.Password);
        }

        /// <summary>
        /// ��֤Token��Ϣ
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