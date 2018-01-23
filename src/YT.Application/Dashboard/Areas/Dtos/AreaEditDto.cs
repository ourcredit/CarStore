using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.Areas.Dtos
{
    /// <summary>
    /// 区域管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(Area))]
    public class AreaEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [DisplayName("区域")]
        [Required]
        [MaxLength(200)]
        public string AreaName { get; set; }

        /// <summary>
        /// 上级id
        /// </summary>
        [DisplayName("上级id")]
        public int? ParentId { get; set; }

    }
}
