using Com.GleekFramework.MigrationSdk;

namespace Org.Gleek.AuthorizeSvc.Upgrations
{
    /// <summary>
    /// 所属行业升级脚本
    /// </summary>
    [Upgration(1712500460001)]
    public class ComIndustryUpgration : Upgration
    {
        /// <summary>
        /// 执行sql文件
        /// </summary>
        /// <returns></returns>
        public async override Task<IEnumerable<string>> ExecuteSqlFilesAsync()
        {
            return await Task.FromResult(new List<string>() { "com_industry.sql" });
        }
    }
}