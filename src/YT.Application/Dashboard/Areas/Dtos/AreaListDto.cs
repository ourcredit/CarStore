using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.Areas.Dtos
{
    /// <summary>
    /// 区域管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Area))]
    public class AreaListDto : EntityDto<int>
    {
        /// <summary>
        /// 区域
        /// </summary>
        [DisplayName("区域")]
        public string AreaName { get; set; }
        /// <summary>
        /// 上级id
        /// </summary>
        [DisplayName("上级id")]
        public int? ParentId { get; set; }
        /// <summary>
        /// 上级对象
        /// </summary>
        [DisplayName("上级对象")]
        public string ParentName { get; set; }
        /// <summary>
        /// 是否指定价格
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
