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
        /// 访问令牌
        /// </summary>
        [JsonProperty("access_token"), JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 令牌的有效期（秒）
        /// </summary>
        [JsonProperty("expires_in"), JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 令牌过期时间
        /// </summary>
        [JsonProperty("expire_time"), JsonPropertyName("expire_time")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        [JsonProperty("refresh_token"), JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}