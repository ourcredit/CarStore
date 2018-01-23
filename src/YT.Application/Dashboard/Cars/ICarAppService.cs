using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YT.Dashboard.Cars.Dtos;
using YT.Dto;

namespace YT.Dashboard.Cars
{
    /// <summary>
    /// 车辆管理服务接口
    /// </summary>
    public interface ICarAppService : IApplicationService
    {
        #region 车辆管理管理

        /// <summary>
        /// 根据查询条件获取车辆管理分页列表
        /// </summary>
        Task<PagedResultDto<CarListDto>> GetPagedCarsAsync(GetCarInput input);

        /// <summary>
        /// 通过Id获取车辆管理信息进行编辑或修改 
        /// </summary>
        Task<GetCarForEditOutput> GetCarForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取车辆管理ListDto信息
        /// </summary>
        Task<CarListDto> GetCarByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改车辆管理
        /// </summary>
        Task CreateOrUpdateCarAsync(CreateOrUpdateCarInput input);


        /// <summary>
        /// 删除车辆管理
        /// </summary>
        Task DeleteCarAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除车辆管理
        /// </summary>
        Task BatchDeleteCarAsync(List<int> input);

        #endregion

        #region Excel导出功能



        /// <summary>
        /// 获取车辆管理信息转换为Excel
        /// </summary>
        /// <returns></returns>
        Task<FileDto> GetCarToExcel();

        #endregion





    }
}
