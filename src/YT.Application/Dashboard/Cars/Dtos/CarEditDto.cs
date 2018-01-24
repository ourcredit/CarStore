using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using YT.Models;

namespace YT.Dashboard.Cars.Dtos
{
    /// <summary>
    /// 车辆管理编辑用Dto
    /// </summary>
    [AutoMap(typeof(Car))]
    public class CarEditDto
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public int? Id { get; set; }
        /// <summary>
        /// 是否网约车
        /// </summary>
        public bool IsNet { get; set; }
        /// <summary>
        /// 唯一指定key
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        [DisplayName("车牌号")]
        [Required]
        public string CarNum { get; set; }

        /// <summary>
        /// 司机手机
        /// </summary>
        [DisplayName("司机手机")]
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [DisplayName("区域")]
        [Required]
        public int AreaId { get; set; }

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
        /// 附件集合
        /// </summary>
        [DisplayName("附件集合")]
        public List<CarProfile> CarProfiles { get; set; }

    }
}
