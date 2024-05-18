using Newtonsoft.Json;
using Org.Gleek.AuthorizeSvc.Entitys;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// 用户授权模型
    /// </summary>
    public class UserAuthModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name")]
        [JsonProperty("user_name"), JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nick_name")]
        [JsonProperty("nick_name"), JsonPropertyName("nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Column("avatar")]
        [JsonProperty("avatar"), JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("gender")]
        [JsonProperty("gender"), JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// 个人名片
        /// </summary>
        [Column("business_card")]
        [JsonProperty("business_card"), JsonPropertyName("business_card")]
        public string BusinessCard { get; set; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        [Column("is_admin")]
        [JsonProperty("is_admin"), JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [Column("register_time", TypeName = "datetime")]
        [JsonProperty("register_time"), JsonPropertyName("register_time")]
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        [Column("last_login_time", TypeName = "datetime")]
        [JsonProperty("last_login_time"), JsonPropertyName("last_login_time")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最近登出时间
        /// </summary>
        [Column("last_logout_time", TypeName = "datetime")]
        [JsonProperty("last_logout_time"), JsonPropertyName("last_logout_time")]
        public DateTime LastLogoutTime { get; set; }
    }
}