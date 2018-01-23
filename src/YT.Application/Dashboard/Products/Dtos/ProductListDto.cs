using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.Products.Dtos
{
    /// <summary>
    /// 商品管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Product))]
    public class ProductListDto : EntityDto<int>
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [DisplayName("商品名称")]
        public string ProductName { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [DisplayName("商品编号")]
        public string ProductNum { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
