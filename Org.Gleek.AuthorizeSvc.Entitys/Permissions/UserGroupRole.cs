using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户组角色关联表
    /// </summary>
    [Table("user_group_role")]
    [Comment("用户组角色关联表")]
    [Index("idx_user_group_role_role_id", nameof(RoleId))]
    [Index("idx_user_group_role_user_group_id", nameof(UserGroupId))]
    public class UserGroupRole : VersionTable
    {
        /// <summary>
        /// 用户组
        /// </summary>
        [Comment("用户组")]
        [Column("user_group_id")]
        [JsonProperty("user_group_id"), JsonPropertyName("user_group_id")]
        public long UserGroupId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Column("role_id")]
        [Comment("角色Id")]
        [JsonProperty("role_id"), JsonPropertyName("role_id")]
        public long RoleId { get; set; }
    }
}