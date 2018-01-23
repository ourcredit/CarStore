using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YT.Dashboard.Products.Dtos;
using YT.Dto;

namespace YT.Dashboard.Products
{
    /// <summary>
    /// 商品管理服务接口
    /// </summary>
    public interface IProductAppService : IApplicationService
    {
        #region 商品管理管理

        /// <summary>
        /// 根据查询条件获取商品管理分页列表
        /// </summary>
        Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(GetProductInput input);

        /// <summary>
        /// 通过Id获取商品管理信息进行编辑或修改 
        /// </summary>
        Task<GetProductForEditOutput> GetProductForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取商品管理ListDto信息
        /// </summary>
        Task<ProductListDto> GetProductByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改商品管理
        /// </summary>
        Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input);

        /// <summary>
        /// 删除商品管理
        /// </summary>
        Task DeleteProductAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除商品管理
        /// </summary>
        Task BatchDeleteProductAsync(List<int> input);

        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取商品管理信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetProductToExcel();

        #endregion





    }
}
