using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using YT.Dashboard.WareHouses.Dtos;
using YT.DataExporting.Excel.EpPlus;
using YT.Dto;

namespace YT.Dashboard.WareHouses.Exporting
{
    /// <summary>
    /// 仓库管理的导出EXCEL功能的实现
    /// </summary>
    public class WareHouseListExcelExporter : EpPlusExcelExporterBase, IWareHouseListExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public WareHouseListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }



        /// <summary>
        /// 导出仓库管理到EXCEL文件
        /// <param name="wareHouseListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportWareHouseToFile(List<WareHouseListDto> wareHouseListDtos)
        {


            var file = CreateExcelPackage("wareHouseList.xlsx", excelPackage =>
            {

                var sheet = excelPackage.Workbook.Worksheets.Add(L("WareHouse"));
                sheet.OutLineApplyStyle = true;

                AddHeader(
                    sheet,
                      L("WareNum"),
                     L("WareName"),
                     L("AreaId"),
                     L("Area"),
                     L("CreationTime")
                    );
                AddObjects(sheet, 2, wareHouseListDtos,

                    _ => _.WareNum,

                    _ => _.WareName,

                    _ => _.AreaId,

                    _ => _.AreaName,

                    _ => _timeZoneConverter.Convert(_.CreationTime, _abpSession.TenantId, _abpSession.GetUserId())
                );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

                for (var i = 1; i <= 5; i++)
                {
                    sheet.Column(i).AutoFit();
                }

            });
            return file;

        }


    }
}
