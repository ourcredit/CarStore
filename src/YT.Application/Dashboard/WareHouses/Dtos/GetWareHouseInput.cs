using Abp.Runtime.Validation;
using YT.Dto;

namespace YT.Dashboard.WareHouses.Dtos
{
	/// <summary>
    /// 仓库管理查询Dto
    /// </summary>
    public class GetWareHouseInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 名称
		/// </summary>
		public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
		public string Num { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
		public string Area { get; set; }

        /// <inheritdoc />
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
    /// <summary>
    /// 修改负责人input
    /// </summary>
    public class ChangeHouseChargeUserInput
    {
        /// <summary>
        /// 仓库id
        /// </summary>
        public int  HouseId { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        public long  UserId { get; set; }
    }
}
