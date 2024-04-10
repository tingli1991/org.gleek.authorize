using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.MigrationSdk;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Org.Gleek.AuthorizeSvc.Entitys
{
    /// <summary>
    /// 所属行业信息表
    /// </summary>
    [Table("com_industry")]
    [Comment("所属行业信息表")]
    public class ComIndustry : VersionTable
    {
        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(255)]
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
        /// 父级
        /// </summary>
        [Comment("父级")]
        [Column("parent_id")]
        [JsonProperty("parent_id"), JsonPropertyName("parent_id")]
        public long ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        [MaxLength(5000)]
        [Column("description")]
        [JsonProperty("description"), JsonPropertyName("description")]
        public string Description { get; set; }
    }
}