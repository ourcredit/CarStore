using System.Collections.Generic;
using YT.Dashboard.Products.Dtos;

namespace YT.Dashboard.Areas.Dtos
{
    /// <summary>
    /// 区域管理新增和编辑时用Dto
    /// </summary>

    public class CreateOrUpdateAreaInput
    {
        /// <summary>
        /// 区域管理编辑Dto
        /// </summary>
        public AreaEditDto AreaEditDto { get; set; }

    }
    /// <summary>
    /// 更新区域价格input
    /// </summary>
    public class UpdateAreaPriceInput
    {
        /// <summary>
        /// 区域id
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 修改对象
        /// </summary>
        public List<AreaProductDto> List { get; set; }
    }
}
