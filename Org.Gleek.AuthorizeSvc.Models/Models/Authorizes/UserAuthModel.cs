using Newtonsoft.Json;
using Org.Gleek.AuthorizeSvc.Entitys;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// 用户授权模型
    /// </summary>
    [Serializable]
    public class UserAuthModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("user_name"), JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nick_name"), JsonPropertyName("nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("avatar"), JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [JsonProperty("gender"), JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// 个人名片
        /// </summary>
        [JsonProperty("business_card"), JsonPropertyName("business_card")]
        public string BusinessCard { get; set; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        [JsonProperty("is_admin"), JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [JsonProperty("register_time"), JsonPropertyName("register_time")]
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        [JsonProperty("last_login_time"), JsonPropertyName("last_login_time")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最近登出时间
        /// </summary>
        [JsonProperty("last_logout_time"), JsonPropertyName("last_logout_time")]
        public DateTime LastLogoutTime { get; set; }
    }
}