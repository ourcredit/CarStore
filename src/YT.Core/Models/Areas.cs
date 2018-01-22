using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace YT.Models
{
    /// <summary>
    /// 区域管理
    /// </summary>
    [Table("area")]
   public class Area:CreationAuditedEntity
    {
        /// <summary>
        /// 区域
        /// </summary>
        [Required,MaxLength(200)]
        public string AreaName { get; set; }
        /// <summary>
        /// 上级id
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 上级对象
        /// </summary>
        public  virtual  Area Parent { get; set; }
        /// <summary>
        /// 层级码
        /// </summary>
        public string LevelCode { get; set; }
        [ForeignKey("ParentId")]
        public virtual  ICollection<Area> Children { get; set; }
        [ForeignKey("AreaId")]
        public  virtual  ICollection<AreaPrice> AreaPrices { get; set; }
    }

    /// <summary>
    /// 区域价格详细设定
    /// </summary>
    [Table("areaprice")]
    public class AreaPrice : CreationAuditedEntity
    {
        /// <summary>
        /// 区域id
        /// </summary>
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 成本
        /// </summary>
        public int Cost { get; set; }

    }
}
