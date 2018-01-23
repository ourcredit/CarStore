using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using YT.Dashboard.Products.Dtos;
using YT.DataExporting.Excel.EpPlus;
using YT.Dto;

namespace YT.Dashboard.Products.Exporting
{
    /// <summary>
    /// 商品管理的导出EXCEL功能的实现
    /// </summary>
    public class ProductListExcelExporter : EpPlusExcelExporterBase, IProductListExcelExporter
    {
     
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public ProductListExcelExporter(ITimeZoneConverter timeZoneConverter,     IAbpSession abpSession)
        {
                       _timeZoneConverter = timeZoneConverter;    
                     _abpSession = abpSession;
        }

    

         /// <summary>
        /// 导出商品管理到EXCEL文件
        /// <param name="productListDtos">导出信息的DTO</param>
        /// </summary>
    public    FileDto ExportProductToFile(List<ProductListDto> productListDtos){


var file=CreateExcelPackage("productList.xlsx",excelPackage=>{

var sheet=excelPackage.Workbook.Worksheets.Add(L("Product"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                          L("ProductName"),  
     L("ProductNum"),  
     L("Description"),  
     L("CreationTime")
                        );
         AddObjects(sheet,2,productListDtos,
            
      _ => _.ProductName,   
       
      _ => _.ProductNum,   
       
      _ => _.Description,
       
 _ =>_timeZoneConverter.Convert( _.CreationTime,_abpSession.TenantId, _abpSession.GetUserId())
);
                    //写个时间转换的吧
          //var creationTimeColumn = sheet.Column(10);
                    //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

        for (var i = 1; i <= 6; i++)
                    {
                        sheet.Column(i).AutoFit();
                    }       

});
   return file;

}


 

 
  

    }
    }
