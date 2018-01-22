using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace YT.Models
{
    /// <summary>
    /// 商城订单
    /// </summary>
    [Table("storeorder")]
    public class StoreOrder : CreationAuditedEntity
    {
        /// <summary>
        /// 车辆id
        /// </summary>
        public int CarId { get; set; }
        /// <summary>
        /// 车辆车牌
        /// </summary>
        public string CarNum { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }
      
        /// <summary>
        /// 订单状态
        /// </summary>
        public bool? OrderState { get; set; }
        /// <summary>
        /// 微信订单
        /// </summary>
        public string WechatOrder { get; set; }
        /// <summary>
        /// 订单商品详情
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual  ICollection<OrderList > OrderList { get; set; }
    }
    /// <summary>
    /// 订单商品
    /// </summary>
    [Table("orderlist")]
    public class OrderList : CreationAuditedEntity
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public  int OrderId { get; set; }
       
        /// <summary>
        /// 产品id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public int ProductName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }
    }
}
