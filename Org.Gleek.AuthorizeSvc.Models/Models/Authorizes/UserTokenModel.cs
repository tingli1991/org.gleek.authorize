using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// 用户Token模型
    /// </summary>
    [Serializable]
    public class UserTokenModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 登录TOKEN
        /// </summary>
        [JsonProperty("token"), JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// 刷新TOKEN
        /// </summary>
        [JsonProperty("refresh_token"), JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 有效期(单位：秒)
        /// </summary>
        [JsonProperty("expire_seconds"), JsonPropertyName("expire_seconds")]
        public int ExpireSeconds { get; set; }
    }
}