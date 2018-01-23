using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using YT.Models;
using YT.Storage;

namespace YT.Dashboard.Products.Dtos
{
    /// <summary>
    /// 商品管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductEditDto
    {

        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DisplayName("商品名称")]
        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        [DisplayName("商品编号")]
        [Required]
        [MaxLength(200)]
        public string ProductNum { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [DisplayName("图片")]
        public Guid? ProfileId { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [DisplayName("")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [DisplayName("价格")]
        public int Price { get; set; }

        /// <summary>
        /// 成本价格
        /// </summary>
        [DisplayName("成本价格")]
        public int Cost { get; set; }

    }
}
