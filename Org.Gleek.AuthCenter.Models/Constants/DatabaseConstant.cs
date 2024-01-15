namespace Org.Gleek.AuthCenter.Models
{
    /// <summary>
    /// 数据库常量
    /// </summary>
    public static class DatabaseConstant
    {
        /// <summary>
        /// 认证授权服务读写库配置
        /// </summary>
        public const string AuthCenterHosts = "ConnectionStrings:AuthCenterHosts";

        /// <summary>
        /// 认证授权服务只读库配置
        /// </summary>
        public const string AuthCenterOnlyHosts = "ConnectionStrings:AuthCenterOnlyHosts";
    }
}