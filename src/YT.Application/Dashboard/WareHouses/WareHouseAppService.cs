using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using YT.Dashboard.WareHouses.Dtos;
using YT.Dashboard.WareHouses.Exporting;
using YT.Dto;
using YT.Models;

namespace YT.Dashboard.WareHouses
{
    /// <summary>
    /// 仓库管理服务实现
    /// </summary>
    [AbpAuthorize]


    public class WareHouseAppService : YtAppServiceBase, IWareHouseAppService
    {
        private readonly IRepository<WareHouse, int> _wareHouseRepository;
        private readonly IRepository<Area, int> _areaRepository;
        private readonly IWareHouseListExcelExporter _wareHouseListExcelExporter;
        /// <summary>
        /// 构造方法
        /// </summary>
        public WareHouseAppService(IRepository<WareHouse, int> wareHouseRepository,
      IWareHouseListExcelExporter wareHouseListExcelExporter, IRepository<Area, int> areaRepository)
        {
            _wareHouseRepository = wareHouseRepository;
            _wareHouseListExcelExporter = wareHouseListExcelExporter;
            _areaRepository = areaRepository;
        }


        #region 实体的自定义扩展方法
        private IQueryable<WareHouse> WareHouseRepositoryAsNoTrack => _wareHouseRepository.GetAll().AsNoTracking();


        #endregion
        #region 仓库管理管理
        /// <summary>
        /// 根据查询条件获取仓库管理分页列表
        /// </summary>
        public async Task<PagedResultDto<WareHouseListDto>> GetPagedWareHousesAsync(GetWareHouseInput input)
        {
            var area = await _areaRepository.FirstOrDefaultAsync(c => c.AreaName.Contains(input.Area));
            List<int> p=new List<int>();
            if (area != null)
            {
                var arr = await _areaRepository.GetAllListAsync(c => c.LevelCode.Contains(area.LevelCode));
                 p = arr.Select(c => c.Id).ToList();
            }
         
            var query = WareHouseRepositoryAsNoTrack;
            query = query.WhereIf(!input.Name.IsNullOrWhiteSpace(), c => c.WareName.Contains(input.Name))
                .WhereIf(!input.Num.IsNullOrWhiteSpace(), c => c.WareNum.Contains(input.Num))
                .WhereIf(p.Any(), c => p.Contains(c.AreaId));

            var wareHouseCount = await query.CountAsync();

            var wareHouses = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var wareHouseListDtos = wareHouses.MapTo<List<WareHouseListDto>>();
            return new PagedResultDto<WareHouseListDto>(
            wareHouseCount,
            wareHouseListDtos
            );
        }

        /// <summary>
        /// 通过Id获取仓库管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetWareHouseForEditOutput> GetWareHouseForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetWareHouseForEditOutput();

            WareHouseEditDto wareHouseEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _wareHouseRepository.GetAsync(input.Id.Value);
                wareHouseEditDto = entity.MapTo<WareHouseEditDto>();
            }
            else
            {
                wareHouseEditDto = new WareHouseEditDto();
            }

            output.WareHouse = wareHouseEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取仓库管理ListDto信息
        /// </summary>
        public async Task<WareHouseListDto> GetWareHouseByIdAsync(EntityDto<int> input)
        {
            var entity = await _wareHouseRepository.GetAsync(input.Id);

            return entity.MapTo<WareHouseListDto>();
        }







        /// <summary>
        /// 新增或更改仓库管理
        /// </summary>
        public async Task CreateOrUpdateWareHouseAsync(CreateOrUpdateWareHouseInput input)
        {
            if (input.WareHouseEditDto.Id.HasValue)
            {
                await UpdateWareHouseAsync(input.WareHouseEditDto);
            }
            else
            {
                await CreateWareHouseAsync(input.WareHouseEditDto);
            }
        }

        /// <summary>
        /// 新增仓库管理
        /// </summary>
        protected virtual async Task<WareHouseEditDto> CreateWareHouseAsync(WareHouseEditDto input)
        {
            var entity = input.MapTo<WareHouse>();
            entity = await _wareHouseRepository.InsertAsync(entity);
            return entity.MapTo<WareHouseEditDto>();
        }

        /// <summary>
        /// 编辑仓库管理
        /// </summary>
        protected virtual async Task UpdateWareHouseAsync(WareHouseEditDto input)
        {
            var entity = await _wareHouseRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);
            await _wareHouseRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除仓库管理
        /// </summary>
        public async Task DeleteWareHouseAsync(EntityDto<int> input)
        {
            await _wareHouseRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除仓库管理
        /// </summary>
        public async Task BatchDeleteWareHouseAsync(List<int> input)
        {
            await _wareHouseRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
        #region 仓库管理的Excel导出功能
        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>

        public async Task<FileDto> GetWareHouseToExcel()
        {
            var entities = await _wareHouseRepository.GetAll().ToListAsync();

            var dtos = entities.MapTo<List<WareHouseListDto>>();

            var fileDto = _wareHouseListExcelExporter.ExportWareHouseToFile(dtos);



            return fileDto;
        }


        #endregion










    }
}
