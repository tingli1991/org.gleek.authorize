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
    /// 操作表
    /// </summary>
    [Comment("操作表")]
    [Table("operation")]
    public class Operation : VersionTable
    {
        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(100)]
        [Column("code")]
        [Comment("编码")]
        [JsonProperty("code"), JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(255)]
        [Column("name")]
        [Comment("名称")]
        [JsonProperty("name"), JsonPropertyName("name")]
        public string Name { get; set; }

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