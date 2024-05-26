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
    /// 员工信息表
    /// </summary>
    [Comment("员工信息表")]
    [Table("org_employee")]
    [Serializable, ProtoContract]
    [Index("idx_org_employee_code", nameof(Code))]
    [Index("idx_org_employee_version", nameof(Version))]
    [Index("idx_org_employee_create_time", nameof(CreateTime))]
    public class Employee : ITable
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
        /// 直属领导
        /// </summary>
        [ProtoMember(2)]
        [Comment("直属领导")]
        [Column("direct_leader_id")]
        [JsonProperty("direct_leader_id"), JsonPropertyName("direct_leader_id")]
        public long DirectLeaderId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(3)]
        [Column("code")]
        [Comment("工号")]
        [JsonProperty("code"), JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(4)]
        [Comment("姓名")]
        [Column("name")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(5)]
        [Comment("手机")]
        [Column("phone")]
        [JsonProperty("phone"), JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        [ProtoMember(6)]
        [Column("status")]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EmployeeStatus Status { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [ProtoMember(7)]
        [Comment("证件类型")]
        [Column("identity_type")]
        [JsonProperty("identity_type"), JsonPropertyName("identity_type")]
        public IdentityType IdentityType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [MaxLength(80)]
        [ProtoMember(8)]
        [Comment("证件号码")]
        [Column("identity_no")]
        [JsonProperty("identity_no"), JsonPropertyName("identity_no")]
        public string IdentityNo { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(100)]
        [ProtoMember(9)]
        [Comment("邮箱")]
        [Column("email")]
        [JsonProperty("email"), JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// 雇佣时间
        /// </summary>
        [ProtoMember(10)]
        [Comment("雇佣时间")]
        [Column("hire_time")]
        [JsonProperty("hire_time"), JsonPropertyName("hire_time")]
        public DateTime HireTime { get; set; }

        /// <summary>
        /// 解雇时间
        /// </summary>
        [ProtoMember(11)]
        [Comment("解雇时间")]
        [Column("fire_time")]
        [JsonProperty("fire_time"), JsonPropertyName("fire_time")]
        public DateTime FireTime { get; set; }

        /// <summary>
        /// 转正时间
        /// </summary>
        [ProtoMember(12)]
        [Comment("转正时间")]
        [Column("confirmation_time")]
        [JsonProperty("confirmation_time"), JsonPropertyName("confirmation_time")]
        public DateTime ConfirmationTime { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [ProtoMember(13)]
        [Comment("生日")]
        [Column("birth_time")]
        [JsonProperty("birth_time"), JsonPropertyName("birth_time")]
        public DateTime BirthTime { get; set; }

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
        /// 描述
        /// </summary>
        [ProtoMember(19)]
        [MaxLength(500)]
        [Comment("描述")]
        [Column("description")]
        [JsonProperty("description"), JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        [ProtoMember(20)]
        [Comment("备注")]
        [Column("remark")]
        [JsonProperty("remark"), JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}