using Com.GleekFramework.AutofacSdk;

namespace Org.Gleek.AuthorizeSvc.Repository
{
    /// <summary>
    /// 基础仓储服务
    /// </summary>
    public class BaseRepository : IBaseAutofac
    {
        /// <summary>
        /// 认证授权仓储(读写)
        /// </summary>
        public AuthorizeRepository AuthorizeRepository { get; set; }

        /// <summary>
        /// 认证授权仓储(只读)
        /// </summary>
        public AuthorizeOnlyRepository AuthorizeOnlyRepository { get; set; }
    }
}