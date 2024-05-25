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
        /// 操作频繁
        /// </summary>
        [Description("操作频繁")]
        FREQUENT_OPERATION = 100100,

        /// <summary>
        /// 非法请求
        /// </summary>
        [Description("非法请求")]
        ILLEGAL_REQUEST = 100101,

        /// <summary>
        /// 未知的用户
        /// </summary>
        [Description("未知的用户")]
        UNKNOWN_USER = 100102,

        /// <summary>
        /// 请输入用户名
        /// </summary>
        [Description("请输入用户名或密码")]
        USER_NAME_OR_PASSWORD_REQUIRED = 100103,

        /// <summary>
        /// 用户名密码错误
        /// </summary>
        [Description("用户名密码错误")]
        USER_NAME_OR_PASSWORD_ERROR = 100104,

        /// <summary>
        /// TOKEN无效
        /// </summary>
        [Description("TOKEN无效")]
        TOKEN_INVALID = 100105,

        /// <summary>
        /// 请输入TOKEN
        /// </summary>
        [Description("请输入TOKEN")]
        TOKEN_REQUIRED = 100106,

        /// <summary>
        /// REFRESH_TOKEN无效
        /// </summary>
        [Description("REFRESH_TOKEN无效")]
        REFRESH_TOKEN_INVALID = 100107,

        /// <summary>
        /// 请输入REFRESH_TOKEN
        /// </summary>
        [Description("请输入REFRESH_TOKEN")]
        REFRESH_TOKEN_REQUIRED = 100108,
    }
}