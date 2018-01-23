using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using YT.Dashboard.Cars.Dtos;
using YT.Dashboard.Cars.Exporting;
using YT.Dto;
using YT.Models;

namespace YT.Dashboard.Cars
{
    /// <summary>
    /// 车辆管理服务实现
    /// </summary>
    [AbpAuthorize]


    public class CarAppService : YtAppServiceBase, ICarAppService
    {
        private readonly IRepository<Car, int> _carRepository;
        private readonly ICarListExcelExporter _carListExcelExporter;
        /// <summary>
        /// 构造方法
        /// </summary>
        public CarAppService(IRepository<Car, int> carRepository
      , ICarListExcelExporter carListExcelExporter
  )
        {
            _carRepository = carRepository;
            _carListExcelExporter = carListExcelExporter;
        }


        #region 实体的自定义扩展方法
        private IQueryable<Car> CarRepositoryAsNoTrack => _carRepository.GetAll().AsNoTracking();


        #endregion


        #region 车辆管理管理

        /// <summary>
        /// 根据查询条件获取车辆管理分页列表
        /// </summary>
        public async Task<PagedResultDto<CarListDto>> GetPagedCarsAsync(GetCarInput input)
        {

            var query = CarRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var carCount = await query.CountAsync();

            var cars = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var carListDtos = cars.MapTo<List<CarListDto>>();
            return new PagedResultDto<CarListDto>(
            carCount,
            carListDtos
            );
        }

        /// <summary>
        /// 通过Id获取车辆管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetCarForEditOutput> GetCarForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCarForEditOutput();

            CarEditDto carEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _carRepository.GetAsync(input.Id.Value);
                carEditDto = entity.MapTo<CarEditDto>();
            }
            else
            {
                carEditDto = new CarEditDto();
            }

            output.Car = carEditDto;
            return output;
        }

        /// <summary>
        /// 通过指定id获取车辆管理ListDto信息
        /// </summary>
        public async Task<CarListDto> GetCarByIdAsync(EntityDto<int> input)
        {
            var entity = await _carRepository.GetAsync(input.Id);

            return entity.MapTo<CarListDto>();
        }
        /// <summary>
        /// 新增或更改车辆管理
        /// </summary>
        public async Task CreateOrUpdateCarAsync(CreateOrUpdateCarInput input)
        {
            if (input.CarEditDto.Id.HasValue)
            {
                await UpdateCarAsync(input.CarEditDto);
            }
            else
            {
                await CreateCarAsync(input.CarEditDto);
            }
        }

        /// <summary>
        /// 新增车辆管理
        /// </summary>
        protected virtual async Task<CarEditDto> CreateCarAsync(CarEditDto input)
        {
            var entity = input.MapTo<Car>();
            entity = await _carRepository.InsertAsync(entity);
            return entity.MapTo<CarEditDto>();
        }

        /// <summary>
        /// 编辑车辆管理
        /// </summary>
        protected virtual async Task UpdateCarAsync(CarEditDto input)
        {

            var entity = await _carRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _carRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除车辆管理
        /// </summary>
        public async Task DeleteCarAsync(EntityDto<int> input)
        {
            await _carRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除车辆管理
        /// </summary>
        public async Task BatchDeleteCarAsync(List<int> input)
        {
            await _carRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 车辆管理的Excel导出功能

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public async Task<FileDto> GetCarToExcel()
        {
            var entities = await _carRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<CarListDto>>();

            var fileDto = _carListExcelExporter.ExportCarToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
