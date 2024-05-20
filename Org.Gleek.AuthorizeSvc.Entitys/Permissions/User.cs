using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using ProtoBuf;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("user")]
    [Comment("用户表")]
    [Serializable, ProtoContract]
    [Index("idx_user_version", nameof(Version))]
    [Index("idx_user_user_name", nameof(UserName))]
    [Index("idx_user_create_time", nameof(CreateTime))]
    public class User : ITable
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("id")]
        [Comment("主键")]
        [ProtoMember(1)]
        [JsonProperty("id"), JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        [ProtoMember(2)]
        [Comment("用户名")]
        [Column("user_name")]
        [JsonProperty("user_name"), JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MaxLength(50)]
        [ProtoMember(3)]
        [Comment("密码")]
        [Column("password")]
        [JsonProperty("password"), JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(50)]
        [ProtoMember(4)]
        [Comment("昵称")]
        [Column("nick_name")]
        [JsonProperty("nick_name"), JsonPropertyName("nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(5)]
        [Comment("头像")]
        [Column("avatar")]
        [JsonProperty("avatar"), JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Comment("性别")]
        [ProtoMember(6)]
        [Column("gender")]
        [DefaultValue(30)]
        [JsonProperty("gender"), JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        [ProtoMember(7)]
        [Column("status")]
        [DefaultValue(10)]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EnableStatus Status { get; set; }

        /// <summary>
        /// 个人名片
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(8)]
        [Comment("个人名片")]
        [Column("business_card")]
        [JsonProperty("business_card"), JsonPropertyName("business_card")]
        public string BusinessCard { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        [ProtoMember(9)]
        [MaxLength(1000)]
        [Comment("个性签名")]
        [Column("signature")]
        [JsonProperty("signature"), JsonPropertyName("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        [ProtoMember(10)]
        [Column("is_admin")]
        [Comment("是否是超级管理员")]
        [JsonProperty("is_admin"), JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [ProtoMember(11)]
        [Comment("注册时间")]
        [Column("register_time", TypeName = "datetime")]
        [JsonProperty("register_time"), JsonPropertyName("register_time")]
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        [ProtoMember(12)]
        [Comment("最近登录时间")]
        [Column("last_login_time", TypeName = "datetime")]
        [JsonProperty("last_login_time"), JsonPropertyName("last_login_time")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最近登出时间
        /// </summary>
        [ProtoMember(13)]
        [Comment("最近登出时间")]
        [Column("last_logout_time", TypeName = "datetime")]
        [JsonProperty("last_logout_time"), JsonPropertyName("last_logout_time")]
        public DateTime LastLogoutTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(14)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(15)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(16)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(17)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(18)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(19)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}