﻿using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户组角色关联表
    /// </summary>
    [Comment("用户组角色关联表")]
    [Serializable, ProtoContract]
    [Table("power_user_group_role")]
    [Index("idx_power_user_group_role_role_id", nameof(RoleId))]
    [Index("idx_power_user_group_role_version", nameof(Version))]
    [Index("idx_power_user_group_role_create_time", nameof(CreateTime))]
    [Index("idx_power_user_group_role_user_group_id", nameof(UserGroupId))]
    public class UserGroupRole : ITable
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
        /// 用户组
        /// </summary>
        [ProtoMember(2)]
        [Comment("用户组")]
        [Column("user_group_id")]
        [JsonProperty("user_group_id"), JsonPropertyName("user_group_id")]
        public long UserGroupId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [ProtoMember(3)]
        [Column("role_id")]
        [Comment("角色Id")]
        [JsonProperty("role_id"), JsonPropertyName("role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(4)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(5)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(6)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(7)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(8)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ProtoMember(9)]
        [MaxLength(500)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}