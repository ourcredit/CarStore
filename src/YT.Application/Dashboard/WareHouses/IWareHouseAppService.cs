using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YT.Dashboard.WareHouses.Dtos;
using YT.Dto;

namespace YT.Dashboard.WareHouses
{
    /// <summary>
    /// 仓库管理服务接口
    /// </summary>
    public interface IWareHouseAppService : IApplicationService
    {
        #region 仓库管理管理

        /// <summary>
        /// 根据查询条件获取仓库管理分页列表
        /// </summary>
        Task<PagedResultDto<WareHouseListDto>> GetPagedWareHousesAsync(GetWareHouseInput input);

        /// <summary>
        /// 通过Id获取仓库管理信息进行编辑或修改 
        /// </summary>
        Task<GetWareHouseForEditOutput> GetWareHouseForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取仓库管理ListDto信息
        /// </summary>
        Task<WareHouseListDto> GetWareHouseByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 修改仓库负责人
        /// </summary>
        /// <returns></returns>
        Task ChangeHouseChargeUserAsync(ChangeHouseChargeUserInput input);

        /// <summary>
        /// 新增或更改仓库管理
        /// </summary>
        Task CreateOrUpdateWareHouseAsync(CreateOrUpdateWareHouseInput input);

        /// <summary>
        /// 删除仓库管理
        /// </summary>
        Task DeleteWareHouseAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除仓库管理
        /// </summary>
        Task BatchDeleteWareHouseAsync(List<int> input);

        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取仓库管理信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetWareHouseToExcel();

        #endregion





    }
}
