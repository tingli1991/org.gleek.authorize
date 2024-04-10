using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 用户组
    /// </summary>
    [Comment("用户组")]
    [Table("user_group")]
    [Index("idx_user_group_parent_id", nameof(ParentId))]
    [Index("idx_user_group_parent_path", nameof(ParentPath))]
    public class UserGroup : VersionTable
    {
        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(255)]
        [Column("name")]
        [Comment("名称")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [Comment("父级")]
        [Column("parent_id")]
        [JsonProperty("parent_id"), JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 父级路径
        /// </summary>
        [MaxLength(500)]
        [Comment("父级路径")]
        [Column("parent_path")]
        [JsonProperty("parent_path"), JsonPropertyName("parent_path")]
        public string ParentPath { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Comment("状态")]
        [Column("status")]
        [DefaultValue(10)]
        [JsonProperty("status"), JsonPropertyName("status")]
        public EnableStatus Status { get; set; }
    }
}