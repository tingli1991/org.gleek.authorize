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
    /// 菜单表
    /// </summary>
    [Comment("菜单表")]
    [Table("power_menu")]
    [Serializable, ProtoContract]
    [Index("idx_power_menu_version", nameof(Version))]
    [Index("idx_power_menu_parent_id", nameof(ParentId))]
    [Index("idx_power_menu_parent_path", nameof(ParentPath))]
    [Index("idx_power_menu_create_time", nameof(CreateTime))]
    public class Menu : ITable
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("id")]
        [ProtoMember(1)]
        [Comment("主键")]
        [JsonProperty("id"), JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [ProtoMember(2)]
        [MaxLength(255)]
        [Column("name")]
        [Comment("名称")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [ProtoMember(3)]
        [Comment("排序")]
        [Column("order")]
        [JsonProperty("order"), JsonPropertyName("order")]
        public long Order { get; set; }

        /// <summary>
        /// ICON图标
        /// </summary>
        [MaxLength(80)]
        [Column("icon")]
        [ProtoMember(4)]
        [Comment("ICON图标")]
        [JsonProperty("icon"), JsonPropertyName("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 资源路径
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(5)]
        [Column("path")]
        [Comment("资源路径")]
        [JsonProperty("path"), JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [ProtoMember(6)]
        [Comment("父级")]
        [Column("parent_id")]
        [JsonProperty("parent_id"), JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 父级路径
        /// </summary>
        [ProtoMember(7)]
        [MaxLength(500)]
        [Comment("父级路径")]
        [Column("parent_path")]
        [JsonProperty("parent_path"), JsonPropertyName("parent_path")]
        public string ParentPath { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [ProtoMember(8)]
        [Comment("状态")]
        [Column("status")]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EnableStatus Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(9)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(10)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(11)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(12)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(13)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(14)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}