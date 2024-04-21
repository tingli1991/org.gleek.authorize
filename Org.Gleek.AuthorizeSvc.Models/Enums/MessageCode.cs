using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// 错误信息枚举
    /// </summary>
    [Serializable]
    public enum MessageCode
    {
        /// <summary>
        /// 未知的用户
        /// </summary>
        [Description("未知的用户")]
        UNKNOWN_USER = 100100,

        /// <summary>
        /// 请输入用户名
        /// </summary>
        [Description("请输入用户名或密码")]
        USER_NAME_OR_PASSWORD_REQUIRED = 100101,

        /// <summary>
        /// 用户名密码错误
        /// </summary>
        [Description("用户名密码错误")]
        USER_NAME_OR_PASSWORD_ERROR = 100102,

        /// <summary>
        /// TOKEN无效
        /// </summary>
        [Description("TOKEN无效")]
        TOKEN_INVALID = 100103
    }
}