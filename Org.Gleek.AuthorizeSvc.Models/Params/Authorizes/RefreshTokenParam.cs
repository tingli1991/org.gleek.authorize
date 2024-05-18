using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models.Models
{
    /// <summary>
    /// 刷新TOKEN请求参数
    /// </summary>
    public class RefreshTokenParam
    {
        /// <summary>
        /// 刷新token
        /// </summary>
        [Required(ErrorMessage = nameof(MessageCode.REFRESH_TOKEN_REQUIRED))]
        [JsonProperty("refresh_token"), JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}