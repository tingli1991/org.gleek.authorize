using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public enum IdentityType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 身份证
        /// </summary>
        [Description("身份证")]
        IdCard = 10,

        /// <summary>
        /// 护照
        /// </summary>
        [Description("护照")]
        Passport = 20
    }
}