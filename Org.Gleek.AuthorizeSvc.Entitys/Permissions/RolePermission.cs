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
    /// 角色权限关联表
    /// </summary>
    [Table("power_role_permission")]
    [Comment("角色权限关联表")]
    [Serializable, ProtoContract]
    [Index("idx_power_role_permission_role_id", nameof(RoleId))]
    [Index("idx_power_role_permission_version", nameof(Version))]
    [Index("idx_power_role_permission_create_time", nameof(CreateTime))]
    [Index("idx_power_role_permission_permission_id", nameof(PermissionId))]
    public class RolePermission : ITable
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
        /// 角色Id
        /// </summary>
        [ProtoMember(2)]
        [Column("role_id")]
        [Comment("角色Id")]
        [JsonProperty("role_id"), JsonPropertyName("role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        [ProtoMember(3)]
        [Comment("权限Id")]
        [Column("permission_id")]
        [JsonProperty("permission_id"), JsonPropertyName("permission_id")]
        public long PermissionId { get; set; }

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
        [ProtoMember(5)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(6)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(7)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ProtoMember(8)]
        [MaxLength(500)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}