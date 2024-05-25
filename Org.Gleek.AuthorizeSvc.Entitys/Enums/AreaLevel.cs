using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 地区级别
    /// </summary>
    [Serializable]
    public enum AreaLevel
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 省份
        /// </summary>
        [Description("省份")]
        Province = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("市")]
        City = 2,

        /// <summary>
        /// 区县
        /// </summary>
        [Description("区县")]
        District = 3,

        /// <summary>
        /// 城镇/街道
        /// </summary>
        [Description("城镇/街道")]
        Street = 4
    }
}