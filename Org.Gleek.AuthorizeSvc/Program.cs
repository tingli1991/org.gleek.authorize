using Com.GleekFramework.AttributeSdk;
using Com.GleekFramework.AutofacSdk;
using Com.GleekFramework.ConfigSdk;
using Com.GleekFramework.DapperSdk;
using Com.GleekFramework.HttpSdk;
using Com.GleekFramework.MigrationSdk;
using Com.GleekFramework.NacosSdk;
using Com.GleekFramework.QueueSdk;
using Com.GleekFramework.RabbitMQSdk;
using Com.GleekFramework.RedisSdk;
using Org.Gleek.AuthorizeSvc.Models;

namespace Com.GleekFramework.AppSvc
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// 主函数
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            await CreateDefaultHostBuilder(args)
                 .Build()
                 .SubscribeQueue()
                 .SubscribeRabbitMQ(config => config.Get<RabbitConsumerOptions>(RabbitConfig.RabbitConsumerOptions))
                 .RunAsync();
        }

        /// <summary>
        /// 创建默认的主机
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder CreateDefaultHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseAutofac()
            .UseConfig()
            .UseCsRedis()
            .UseNacosConf()
            .UseHttpClient()
            .UseConfigAttribute()
            .UseGleekWebHostDefaults<Startup>()
            .UseDapper(DatabaseConstant.AuthCenterHosts, DatabaseConstant.AuthCenterOnlyHosts)
            .UseDapperColumnMap("Org.Gleek.AuthorizeSvc.Entitys", "Org.Gleek.AuthorizeSvc.Models")
            .UseMigrations((config) => new MigrationOptions()
            {
                DatabaseType = DatabaseType.MySQL,
                ConnectionString = config.Get(DatabaseConstant.AuthCenterHosts)
            });
    }
}