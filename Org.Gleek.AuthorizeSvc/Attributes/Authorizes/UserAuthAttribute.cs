using Com.GleekFramework.AutofacSdk;
using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Com.GleekFramework.HttpSdk;
using Com.GleekFramework.NLogSdk;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
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
        /// 日志服务
        /// </summary>
        private static readonly NLogService NLogService = AutofacProvider.GetService<NLogService>();

        /// <summary>
        /// 登录聚合服务
        /// </summary>
        private static readonly AuthAggregateService AuthAggregateService = AutofacProvider.GetService<AuthAggregateService>();

        /// <summary>
        /// 授权方法
        /// </summary>
        /// <param name="context"></param>
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;//请求参数
            var beginTime = DateTime.Now.ToCstTime();//开始授权时间
            var result = new ContractResult<UserAuthModel>();//返回值
            var headers = context.HttpContext.Request.Headers;//请求头
            try
            {
                if (!headers.TryGetValue(UserAuthConstant.AUTH_HEADER_KEY, out StringValues token))
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return;
                }

                if (token.IsNullOrEmpty())
                {
                    result.SetError(MessageCode.TOKEN_INVALID);
                    return;
                }
                result = await AuthAggregateService.ValidateAccessTokenAsync(token);

                //附加Http参数上下文
                context.HttpContext.Items.Add(UserAuthConstant.AUTH_HEADER_KEY, token);
                context.HttpContext.Items.Add(UserAuthConstant.USER_INFO_KEY, result.Data);
            }
            catch (Exception ex)
            {
                var url = $"{request.Host}/{request.Path}";//接口路径               
                var requestBody = request.GetRequestBody();//Body参数
                var totalMilliseconds = (long)(DateTime.Now.ToCstTime() - beginTime).TotalMicroseconds;
                NLogService.Error($"【用户授权】Body参数：{requestBody}，Query参数：{request.Query}，返回值：{result.SerializeObject()}，异常：{ex}", headers.GetSerialNo(), url, totalMilliseconds);
            }
            finally
            {
                if (TokenExpired && !result.IsSuceccful())
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.OK,//状态码
                        Content = result.SerializeObject(),//序列化
                        ContentType = "application/json;charset=utf-8",//设置返回格式
                    };
                }
            }
        }
    }
}