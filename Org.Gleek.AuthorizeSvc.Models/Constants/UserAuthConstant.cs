using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// 用户授权相关常量
    /// </summary>
    public class UserAuthConstant
    {
        /// <summary>
        /// Token的有效期
        /// </summary>
        public const int EXPIRE_SECONDS = 7200;

        /// <summary>
        /// 用户信息键
        /// </summary>
        public const string USER_INFO_KEY = "USER_INFO";

        /// <summary>
        /// Token的头部键名称
        /// </summary>
        public const string AUTH_HEADER_KEY = "Authorization";

        /// <summary>
        /// 生成加密Key
        /// </summary>
        public const string SECRET_KEY = "M02cnQ51Ji97vwT4MO5nvlqvx68BhdEz";

        /// <summary>
        /// 
        /// </summary>
        public static SymmetricSecurityKey SymmetricSecurityKey = new(Encoding.UTF8.GetBytes(SECRET_KEY));

        /// <summary>
        /// 
        /// </summary>
        public static SigningCredentials SigningCredentials = new(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
    }
}