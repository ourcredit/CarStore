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
        /// 区域层级
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 区域对象
        /// </summary>
        public  virtual  Area Area { get; set; }
        public bool IsDeleted { get; set; }
    }
    /// <summary>
    /// 人员 仓库关系表
    /// </summary>
    [Table("userwarehouse")]
    public class UserWareHouse : CreationAuditedEntity, ISoftDelete
    {
        /// <summary>
        ///人员id
        /// </summary>
        public long UserId { get; set; }
        public virtual  User User { get; set; }
        public int  WareHouseId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
