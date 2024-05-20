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
        /// 用户信息
        /// </summary>
        public UserAuthModel UserInfo { get; set; }
    }
}