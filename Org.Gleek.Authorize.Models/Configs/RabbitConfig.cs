using Com.GleekFramework.ConfigSdk;

namespace Org.Gleek.Authorize.Models
{
    /// <summary>
    /// Rabbit配置
    /// </summary>
    public static partial class RabbitConfig
    {
        /// <summary>
        /// 默认的虚拟主机客户端配置
        /// </summary>
        [Config("RabbitConnectionStrings:DefaultClientHosts")]
        public static string RabbitDefaultClientHosts { get; set; }

        /// <summary>
        /// Rabbit连接订阅配置
        /// </summary>
        public static readonly string RabbitConsumerOptions = "RabbitConnectionOptions";
    }
}