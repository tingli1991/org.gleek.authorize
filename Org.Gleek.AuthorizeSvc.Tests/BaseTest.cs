using Com.GleekFramework.AutofacSdk;
using Com.GleekFramework.ConfigSdk;
using Com.GleekFramework.DapperSdk;
using Com.GleekFramework.HttpSdk;
using Com.GleekFramework.NacosSdk;
using Com.GleekFramework.QueueSdk;
using Org.Gleek.AuthorizeSvc.Models;

namespace Org.Gleek.AuthorizeSvc.Tests
{
    /// <summary>
    /// 基础单元测试类
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// 静态构造函数
        /// </summary>
        static BaseTest()
        {
            CreateDefaultHostBuilder()
                .Build()
                .SubscribeQueue();
        }

        /// <summary>
        /// 创建默认的主机
        /// </summary>
        /// <returns></returns>
        private static IHostBuilder CreateDefaultHostBuilder() =>
            Host.CreateDefaultBuilder()
            .UseAutofac()
            .UseConfig()
            .UseNacosConf()
            .UseHttpClient()
            .UseConfigAttribute()
            .UseDapper(DatabaseConstant.AuthCenterHosts, DatabaseConstant.AuthCenterOnlyHosts)
            .UseDapperColumnMap("Org.Gleek.AuthorizeSvc.Entitys", "Org.Gleek.AuthorizeSvc.Models");
    }
}