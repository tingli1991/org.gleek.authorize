using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
    [Table("user_role")]
    [Comment("用户角色关联表")]
    [Index("idx_user_role_user_id", nameof(UserId))]
    [Index("idx_user_role_role_id", nameof(RoleId))]
    public class UserRole : VersionTable
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Column("user_id")]
        [Comment("用户Id")]
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("role_id")]
        [Comment("角色Id")]
        [JsonProperty("role_id"), JsonPropertyName("role_id")]
        public long RoleId { get; set; }
    }
}