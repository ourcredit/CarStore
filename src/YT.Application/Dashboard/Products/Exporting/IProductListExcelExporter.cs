using System.Collections.Generic;
using YT.Dashboard.Products.Dtos;
using YT.Dto;

namespace YT.Dashboard.Products.Exporting
{
    /// <summary>
    /// 商品管理的数据导出功能 
    /// </summary>
    public interface IProductListExcelExporter
    {

        /// <summary>
        /// 导出商品管理到EXCEL文件
        /// <param name="productListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportProductToFile(List<ProductListDto> productListDtos);



    }
}
