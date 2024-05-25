using Com.GleekFramework.AttributeSdk;
using Org.Gleek.AuthorizeSvc.Models;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// 用户授权控制器
    /// </summary>
    public class UserAuthController : BaseController
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken =>
             HttpContext.Items.ContainsKey(UserAuthConstant.AUTH_HEADER_KEY)
            ? $"{HttpContext.Items[UserAuthConstant.AUTH_HEADER_KEY]}" : null;

        /// <summary>
        /// 用户信息
        /// </summary>
        public UserAuthModel UserInfo =>
            HttpContext.Items.ContainsKey(UserAuthConstant.USER_INFO_KEY)
            ? (UserAuthModel)HttpContext.Items[UserAuthConstant.USER_INFO_KEY] : null;
    }
}