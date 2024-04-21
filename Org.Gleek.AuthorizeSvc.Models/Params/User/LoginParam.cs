using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models.Params
{
    /// <summary>
    /// 登录请求参数
    /// </summary>
    [Serializable]
    public class LoginParam
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = nameof(MessageCode.USER_NAME_OR_PASSWORD_REQUIRED))]
        [JsonProperty("user_name"), JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty("password"), JsonPropertyName("password")]
        [Required(ErrorMessage = nameof(MessageCode.USER_NAME_OR_PASSWORD_REQUIRED))]
        public string Password { get; set; }
    }
}