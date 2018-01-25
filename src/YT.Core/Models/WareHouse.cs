using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using YT.Managers.Users;

namespace YT.Models
{
    /// <summary>
    /// 仓库管理
    /// </summary>
    [Table("warehouse")]
    public class WareHouse : CreationAuditedEntity, ISoftDelete
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required,MaxLength(200)]
        public string WareNum { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required, MaxLength(200)]
        public string WareName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 区域层级
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 区域对象
        /// </summary>
        public  virtual  Area Area { get; set; }
        public bool IsDeleted { get; set; }
        public long? ChargeUserId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual User ChargeUser { get; set; }
    }
   
    /// <summary>
    /// 客户信息
    /// </summary>
    [Table("customer")]
    public class Customer:CreationAuditedEntity,ISoftDelete
    {
        public string OpenId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
      
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
  
}
