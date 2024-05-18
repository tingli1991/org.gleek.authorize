using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models.Params
{
    /// <summary>
    /// 验证TOKEN请求参数
    /// </summary>
    public class ValidateTokenParam
    {
        /// <summary>
        /// token
        /// </summary>
        [Required(ErrorMessage = nameof(MessageCode.TOKEN_REQUIRED))]
        [JsonProperty("token"), JsonPropertyName("token")]
        public string Token { get; set; }
    }
}