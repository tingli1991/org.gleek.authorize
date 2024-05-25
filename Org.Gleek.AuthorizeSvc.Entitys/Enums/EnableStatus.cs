using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 启用状态
    /// </summary>
    [Serializable]
    public enum EnableStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enabled = 10,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled = 20
    }
}