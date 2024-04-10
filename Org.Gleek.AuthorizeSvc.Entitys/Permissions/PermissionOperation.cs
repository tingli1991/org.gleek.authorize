using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 权限操作关联表
    /// </summary>
    [Comment("权限操作关联表")]
    [Table("permission_operation")]
    [Index("idx_permission_operation_permission_id", nameof(PermissionId))]
    [Index("idx_permission_operation_operation_id", nameof(OperationId))]
    public class PermissionOperation : VersionTable
    {
        /// <summary>
        /// 权限
        /// </summary>
        [Comment("权限")]
        [Column("permission_id")]
        [JsonProperty("permission_id"), JsonPropertyName("permission_id")]
        public long PermissionId { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        [Comment("操作")]
        [Column("operation_id")]
        [JsonProperty("operation_id"), JsonPropertyName("operation_id")]
        public long OperationId { get; set; }
    }
}