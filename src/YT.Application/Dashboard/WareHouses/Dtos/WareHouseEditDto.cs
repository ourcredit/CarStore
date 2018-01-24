using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.WareHouses.Dtos
{
    /// <summary>
    /// 仓库管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(WareHouse))]
    public class WareHouseEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        [Required]
        [MaxLength(200)]
        public string WareNum { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Required]
        [MaxLength(200)]
        public string WareName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 区域层级
        /// </summary>
        [DisplayName("区域层级")]
        public int AreaId { get; set; }

    }
}
