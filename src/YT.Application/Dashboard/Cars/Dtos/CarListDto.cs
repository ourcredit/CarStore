using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.Cars.Dtos
{
    /// <summary>
    /// 车辆管理列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Car))]
    public class CarListDto : EntityDto<int>
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        [DisplayName("车牌号")]
        public string CarNum { get; set; }
        /// <summary>
        /// 司机手机
        /// </summary>
        [DisplayName("司机手机")]
        public string Mobile { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        [DisplayName("区域")]
        public int AreaId { get; set; }
        /// <summary>
        /// 区域名
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 代理商
        /// </summary>
        [DisplayName("代理商")]
        public string Agent { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName("状态")]
        public bool? State { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        [DisplayName("余额")]
        public int Balance { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
