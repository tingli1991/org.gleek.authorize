using Com.GleekFramework.DapperSdk;
using Org.Gleek.AuthorizeSvc.Models;

namespace Org.Gleek.AuthorizeSvc.Repository
{
    /// <summary>
    /// 授权仓储(只读)
    /// </summary>
    public class AuthorizeOnlyRepository : MySqlRepository
    {
        /// <summary>
        /// 配置文件名称
        /// </summary>
        public override string ConnectionName => DatabaseConstant.AuthCenterOnlyHosts;
    }
}