using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.WareHouses.Dtos
{
	/// <summary>
    /// 仓库管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(WareHouse))]
    public class WareHouseListDto : EntityDto<int>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [DisplayName("编号")]
        public      string WareNum { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public      string WareName { get; set; }
        /// <summary>
        /// 区域层级
        /// </summary>
        [DisplayName("区域层级")]
        public      int AreaId { get; set; }
        /// <summary>
        /// 区域对象
        /// </summary>
        [DisplayName("区域对象")]
        public      string AreaName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
