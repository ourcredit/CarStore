using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using YT.Dashboard.Cars.Dtos;
using YT.DataExporting.Excel.EpPlus;
using YT.Dto;
using YT.Models;

namespace YT.Dashboard.Cars.Exporting
{
    /// <summary>
    /// 车辆管理的导出EXCEL功能的实现
    /// </summary>
    public class CarListExcelExporter : EpPlusExcelExporterBase, ICarListExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public CarListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }



        /// <summary>
        /// 导出车辆管理到EXCEL文件
        /// <param name="carListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportCarToFile(List<CarListDto> carListDtos)
        {


            var file = CreateExcelPackage("carList.xlsx", excelPackage =>
            {

                var sheet = excelPackage.Workbook.Worksheets.Add(L("Car"));
                sheet.OutLineApplyStyle = true;

                AddHeader(
                    sheet,
                      L("CarNum"),
 L("Mobile"),
 L("AreaId"),
 L("Area"),
 L("Agent"),
 L("State"),
 L("Balance"),
 L("CreationTime")
                    );
                AddObjects(sheet, 2, carListDtos,

             _ => _.CarNum,

             _ => _.Mobile,

             _ => _.AreaId,

             _ => _.AreaName,

             _ => _.Agent,

             _ => _.State,

             _ => _.Balance,

        _ => _timeZoneConverter.Convert(_.CreationTime, _abpSession.TenantId, _abpSession.GetUserId())
       );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

                for (var i = 1; i <= 8; i++)
                {
                    sheet.Column(i).AutoFit();
                }

            });
            return file;

        }







    }
}
