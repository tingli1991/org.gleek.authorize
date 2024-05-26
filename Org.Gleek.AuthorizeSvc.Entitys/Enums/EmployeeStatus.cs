using System.ComponentModel;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 员工状态
    /// </summary>
    public enum EmployeeStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 在职
        /// </summary>
        [Description("在职")]
        OnJob = 10,

        /// <summary>
        /// 出差
        /// </summary>
        [Description("出差")]
        BusinessTrips = 20,

        /// <summary>
        /// 休假
        /// </summary>
        [Description("休假")]
        Vacation = 30,

        /// <summary>
        /// 离职
        /// </summary>
        [Description("离职")]
        Resignation = 40,

        /// <summary>
        /// 退休
        /// </summary>
        [Description("退休")]
        Retire = 50,
    }
}