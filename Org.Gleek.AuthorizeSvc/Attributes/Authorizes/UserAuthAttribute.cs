using Com.GleekFramework.AutofacSdk;
using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Models;
using System.Net;

namespace Org.Gleek.AuthorizeSvc.Attributes
{
    /// <summary>
    /// 用户授权
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class UserAuthAttribute : Attribute, IAuthorizationFilter, IBaseAutofac
    {
        /// <summary>
        /// 是否需要验证TOKEN的有效期（默认：true）
        /// </summary>
        public bool TokenExpired { get; set; } = true;

        /// <summary>
        /// 登录聚合服务
        /// </summary>
        private static AuthAggregateService AuthAggregateService = AutofacProvider.GetService<AuthAggregateService>();

        /// <summary>
        /// 授权方法
        /// </summary>
        /// <param name="context"></param>
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            if (headers.IsNullOrEmpty() || !headers.ContainsKey(UserAuthConstant.AUTH_HEADER_KEY))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = headers[UserAuthConstant.AUTH_HEADER_KEY];//Token信息
            if (token.IsNullOrEmpty())
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var response = await AuthAggregateService.ValidateTokenAsync(token);
            if (TokenExpired && !response.IsSuceccful())
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.OK,//返回状态码设置为200，表示成功
                    Content = JsonConvert.SerializeObject(response),
                    ContentType = "application/json;charset=utf-8",//设置返回格式
                };
                return;
            }

            //附加Http参数上下文
            context.HttpContext.Items.Add(UserAuthConstant.USER_INFO_KEY, response.Data);
        }
    }
}