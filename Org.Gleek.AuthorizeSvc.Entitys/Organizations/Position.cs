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
    /// 职位信息表
    /// </summary>
    [Comment("职位信息表")]
    [Table("org_position")]
    [Serializable, ProtoContract]
    [Index("idx_org_position_code", nameof(Code))]
    [Index("idx_org_position_version", nameof(Version))]
    [Index("idx_org_position_create_time", nameof(CreateTime))]
    public class Position : ITable
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
        /// 编码
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(2)]
        [Column("code")]
        [Comment("编码")]
        [JsonProperty("code"), JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(3)]
        [Comment("姓名")]
        [Column("name")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        [ProtoMember(4)]
        [Column("status")]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EnableStatus Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(5)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(6)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(7)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(8)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(9)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [ProtoMember(10)]
        [MaxLength(500)]
        [Comment("描述")]
        [Column("description")]
        [JsonProperty("description"), JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(11)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}