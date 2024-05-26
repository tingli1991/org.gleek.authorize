using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 公司信息表
    /// </summary>
    [Table("org_company")]
    [Comment("公司信息表")]
    [Serializable, ProtoContract]
    [Index("idx_org_company_version", nameof(Version))]
    [Index("idx_org_company_parent_id", nameof(ParentId))]
    [Index("idx_org_company_parent_path", nameof(ParentPath))]
    [Index("idx_org_company_create_time", nameof(CreateTime))]
    public class Company : ITable
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
        /// 名称
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(2)]
        [Comment("名称")]
        [Column("name")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        [ProtoMember(3)]
        [Column("status")]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EnableStatus Status { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [ProtoMember(4)]
        [Comment("父级")]
        [Column("parent_id")]
        [JsonProperty("parent_id"), JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 父级路径
        /// </summary>
        [ProtoMember(5)]
        [MaxLength(500)]
        [Comment("父级路径")]
        [Column("parent_path")]
        [JsonProperty("parent_path"), JsonPropertyName("parent_path")]
        public string ParentPath { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(6)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(7)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(8)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(9)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(10)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [ProtoMember(11)]
        [MaxLength(500)]
        [Comment("描述")]
        [Column("description")]
        [JsonProperty("description"), JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(12)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}