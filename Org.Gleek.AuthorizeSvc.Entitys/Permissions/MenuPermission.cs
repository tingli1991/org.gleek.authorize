using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 菜单权限关联表
    /// </summary>
    [Table("menu_permission")]
    [Comment("菜单权限关联表")]
    [Index("idx_menu_permission_menu_id", nameof(MenuId))]
    [Index("idx_menu_permission_permission_id", nameof(PermissionId))]
    public class MenuPermission : VersionTable
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Comment("菜单")]
        [Column("menu_id")]
        [JsonProperty("menu_id"), JsonPropertyName("menu_id")]
        public long MenuId { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        [Comment("权限")]
        [Column("permission_id")]
        [JsonProperty("permission_id"), JsonPropertyName("permission_id")]
        public long PermissionId { get; set; }
    }
}