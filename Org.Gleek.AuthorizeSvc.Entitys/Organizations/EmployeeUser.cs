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
    /// 员工用户关系表
    /// </summary>
    [Comment("员工用户关系表")]
    [Serializable, ProtoContract]
    [Table("org_employee_user")]
    [Index("idx_org_employee_user_version", nameof(Version))]
    [Index("idx_org_employee_user_position_id", nameof(UserId))]
    [Index("idx_org_employee_user_create_time", nameof(CreateTime))]
    [Index("idx_org_employee_user_employee_id", nameof(EmployeeId))]
    public class EmployeeUser : ITable
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
        /// 员工Id
        /// </summary>
        [ProtoMember(2)]
        [Comment("员工Id")]
        [Column("employee_id")]
        [JsonProperty("employee_id"), JsonPropertyName("employee_id")]
        public long EmployeeId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        [ProtoMember(3)]
        [Comment("用户Id")]
        [Column("user_id")]
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long UserId { get; set; }

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
        [MaxLength(500)]
        [ProtoMember(9)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}
