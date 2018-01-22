using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using YT.Storage;

namespace YT.Models
{
    /// <summary>
    /// 商品管理
    /// </summary>
    [Table("product")]
   public class Product:CreationAuditedEntity,ISoftDelete
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required,MaxLength(200)]
        public string ProductName { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [Required,MaxLength(200)]

        public string ProductNum { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public Guid? ProfileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  virtual  BinaryObject Profile { get; set; }
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 成本价格
        /// </summary>
        public int Cost { get; set; }
    }
  
}
