using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 角色权限关联表
    /// </summary>
    [Table("role_permission")]
    [Comment("角色权限关联表")]
    [Index("idx_role_permission_role_id", nameof(RoleId))]
    [Index("idx_role_permission_permission_id", nameof(PermissionId))]
    public class RolePermission : VersionTable
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("role_id")]
        [Comment("角色Id")]
        [JsonProperty("role_id"), JsonPropertyName("role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>
        [Comment("权限Id")]
        [Column("permission_id")]
        [JsonProperty("permission_id"), JsonPropertyName("permission_id")]
        public long PermissionId { get; set; }
    }
}