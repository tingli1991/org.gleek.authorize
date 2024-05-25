using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 性别
    /// </summary>
    [Serializable]
    public enum Gender
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Man = 10,

        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        WoMan = 20
    }
}