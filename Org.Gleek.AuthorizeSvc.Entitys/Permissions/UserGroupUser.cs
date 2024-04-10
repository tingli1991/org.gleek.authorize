using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户组用户关联表
    /// </summary>
    [Table("user_group_user")]
    [Comment("用户组用户关联表")]
    [Index("idx_user_group_user_user_id", nameof(UserId))]
    [Index("idx_user_group_user_user_group_id", nameof(UserGroupId))]
    public class UserGroupUser : VersionTable
    {
        /// <summary>
        /// 用户组
        /// </summary>
        [Comment("用户组")]
        [Column("user_group_id")]
        [JsonProperty("user_group_id"), JsonPropertyName("user_group_id")]
        public long UserGroupId { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [Comment("用户")]
        [Column("user_id")]
        [JsonProperty("user_id"), JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}