using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using YT.Storage;

namespace YT.Models
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    [Table("car")]
    public class Car : CreationAuditedEntity, ISoftDelete
    {
        /// <summary>
        /// 唯一指定key
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 是否网约车
        /// </summary>
        public bool IsNet { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNum { get; set; }
        /// <summary>
        /// 司机手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        /// <summary>
        /// 代理商
        /// </summary>
        public string Agent { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool? State { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 附件集合
        /// </summary>
        [ForeignKey("CarId")]
        public virtual  ICollection<CarProfile> CarProfiles { get; set; }
    }
    /// <summary>
    /// 车辆管理附件
    /// </summary>
    [Table("carprofile")]
    public class CarProfile : CreationAuditedEntity
    {
        /// <summary>
        /// 汽车id
        /// </summary>
        public int CarId { get; set; }
        public  virtual  Car Car { get; set; }
        /// <summary>
        /// 附件id
        /// </summary>
        public Guid ProfileId { get; set; }
        public virtual BinaryObject Profile { get; set; }
        public FileType FileType { get; set; }
    }
    /// <summary>
    /// 汽车订单
    /// </summary>
    [Table("carorder")]
    public class CarOrder : CreationAuditedEntity,ISoftDelete
    {
        /// <summary>
        /// 订单好
        /// </summary>
        public string OrderNum  { get; set; }
        /// <summary>
        /// 指定仓库
        /// </summary>
        public int HouseId { get; set; }
        /// <summary>
        /// 仓库对象
        /// </summary>
        public virtual WareHouse House { get; set; }
        /// <summary>
        /// 车辆id
        /// </summary>
        public int CarId  { get; set; }
        public  virtual  Car Car { get; set; }
        /// <summary>
        /// 区域id
        /// </summary>
        public  int AreaId { get; set; }
        public  virtual  Area Area { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState OrderState { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        [ForeignKey("OrderId")]
        public virtual  ICollection<OrderProduct> OrderProducts { get; set; }
    }
    /// <summary>
    /// 订单商品信息
    /// </summary>
    [Table("orderproduct")]
    public class OrderProduct : CreationAuditedEntity
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Total { get; set; }
    }
    /// <summary>
    /// 提现记录
    /// </summary>
    [Table("cargeneration")]
    public class CarGeneration : CreationAuditedEntity, ISoftDelete {
        public int CarId { get; set; }
        public  virtual  Car Car { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public int Balance { get; set; }
        /// <summary>
        /// 取现金额
        /// </summary>
        public int GenerateCost { get; set; }
        /// <summary>
        /// 当前剩余
        /// </summary>
        public int CurrentBalance { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool? State { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
