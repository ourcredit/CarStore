using System.Data;
using Abp.Runtime.Validation;
using YT.Dto;

namespace YT.Dashboard.Cars.Dtos
{
	/// <summary>
    /// 车辆管理查询Dto
    /// </summary>
    public class GetCarInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string CarNum { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
		public string Mobile { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
		public bool? State { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
		public string Area { get; set; }

        /// <summary>
        /// 用于排序的默认值
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
			
		
                Sorting = "Id";
            }
        }
    }
}
