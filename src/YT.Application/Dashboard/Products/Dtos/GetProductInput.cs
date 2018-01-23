using Abp.Runtime.Validation;
using YT.Dto;

namespace YT.Dashboard.Products.Dtos
{
	/// <summary>
    /// 商品管理查询Dto
    /// </summary>
    public class GetProductInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
		public string Num { get; set; }

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
