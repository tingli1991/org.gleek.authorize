﻿using System.ComponentModel;

namespace Org.Gleek.Authorize.Models
{
    /// <summary>
    /// 错误信息枚举
    /// </summary>
    [Serializable]
    public enum MessageCode
    {
        /// <summary>
        /// 请输入时间
        /// </summary>
        [Description("请输入时间")]
        PARAM_REQUIRED_DATE = 100100,
    }
}