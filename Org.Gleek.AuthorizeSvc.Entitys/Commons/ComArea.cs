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
    /// 地区信息表
    /// </summary>
    [Table("com_area")]
    [Comment("地区信息表")]
    [Serializable, ProtoContract]
    [Index("idx_com_area_code", nameof(Code))]
    [Index("idx_com_area_version", nameof(Version))]
    [Index("idx_com_area_parent_id", nameof(ParentId))]
    [Index("idx_com_area_create_time", nameof(CreateTime))]
    public class ComArea : ITable
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
        /// 编码
        /// </summary>
        [ProtoMember(2)]
        [MaxLength(255)]
        [Column("code")]
        [Comment("编码")]
        [JsonProperty("code"), JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        [ProtoMember(3)]
        [MaxLength(255)]
        [Column("name")]
        [Comment("名称")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地区级别
        /// </summary>
        [ProtoMember(4)]
        [Column("level")]
        [Comment("级别")]
        [JsonProperty("level"), JsonPropertyName("level")]
        public AreaLevel Level { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [MaxLength(50)]
        [Column("lng")]
        [ProtoMember(5)]
        [Comment("经度")]
        [JsonProperty("lng"), JsonPropertyName("lng")]
        public string Lng { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [MaxLength(50)]
        [Column("lat")]
        [ProtoMember(6)]
        [Comment("纬度")]
        [JsonProperty("lat"), JsonPropertyName("lat")]
        public string Lat { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [ProtoMember(7)]
        [Comment("父级")]
        [Column("parent_id")]
        [JsonProperty("parent_id"), JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [ProtoMember(8)]
        [Comment("是否删除")]
        [Column("id_deleted")]
        [JsonProperty("id_deleted"), JsonPropertyName("id_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [ProtoMember(9)]
        [Comment("更新时间")]
        [Column("update_time")]
        [JsonProperty("update_time"), JsonPropertyName("update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ProtoMember(10)]
        [Comment("创建时间")]
        [Column("create_time")]
        [JsonProperty("create_time"), JsonPropertyName("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [ProtoMember(11)]
        [Column("version")]
        [Comment("版本号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonProperty("version"), JsonPropertyName("version")]
        public long Version { get; set; }

        /// <summary>
        /// 透传字段
        /// </summary>
        [ProtoMember(12)]
        [MaxLength(500)]
        [Column("extend")]
        [Comment("透传字段")]
        [JsonProperty("extend"), JsonPropertyName("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(13)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}