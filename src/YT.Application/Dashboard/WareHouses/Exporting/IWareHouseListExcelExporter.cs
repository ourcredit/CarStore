using System.Collections.Generic;
using YT.Dashboard.WareHouses.Dtos;
using YT.Dto;

namespace YT.Dashboard.WareHouses.Exporting
{
	/// <summary>
    /// 仓库管理的数据导出功能 
    /// </summary>
    public interface IWareHouseListExcelExporter
    {
       
        /// <summary>
        /// 导出仓库管理到EXCEL文件
        /// <param name="wareHouseListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportWareHouseToFile(List<WareHouseListDto> wareHouseListDtos);



    }
}
