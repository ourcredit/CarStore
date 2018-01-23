using System.Collections.Generic;
using YT.Dashboard.Cars.Dtos;
using YT.Dto;

namespace YT.Dashboard.Cars.Exporting
{
	/// <summary>
    /// 车辆管理的数据导出功能 
    /// </summary>
    public interface ICarListExcelExporter
    {
        
        /// <summary>
        /// 导出车辆管理到EXCEL文件
        /// <param name="carListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportCarToFile(List<CarListDto> carListDtos);



    }
}
