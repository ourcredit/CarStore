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
using YT.Dashboard.Areas.Dtos;
using YT.Models;


namespace YT.Dashboard.Areas
{
    /// <summary>
    /// 区域管理服务实现
    /// </summary>
    [AbpAuthorize]


    public class AreaAppService : YtAppServiceBase, IAreaAppService
    {
        private readonly IRepository<Area, int> _areaRepository;


        /// <summary>
        /// 构造方法
        /// </summary>
        public AreaAppService(IRepository<Area, int> areaRepository

  )
        {
            _areaRepository = areaRepository;

        }


        #region 实体的自定义扩展方法
        private IQueryable<Area> AreaRepositoryAsNoTrack => _areaRepository.GetAll().AsNoTracking();


        #endregion


        #region 区域管理管理

        /// <summary>
        /// 根据查询条件获取区域管理分页列表
        /// </summary>
        public async Task<PagedResultDto<AreaListDto>> GetPagedAreasAsync(GetAreaInput input)
        {

            var query = AreaRepositoryAsNoTrack;

            var areaCount = await query.CountAsync();

            var areas = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();

            var areaListDtos = areas.MapTo<List<AreaListDto>>();
            return new PagedResultDto<AreaListDto>(
            areaCount,
            areaListDtos
            );
        }

        /// <summary>
        /// 通过Id获取区域管理信息进行编辑或修改 
        /// </summary>
        public async Task<GetAreaForEditOutput> GetAreaForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetAreaForEditOutput();

            AreaEditDto areaEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _areaRepository.GetAsync(input.Id.Value);
                areaEditDto = entity.MapTo<AreaEditDto>();
            }
            else
            {
                areaEditDto = new AreaEditDto();
            }

            output.Area = areaEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取区域管理ListDto信息
        /// </summary>
        public async Task<AreaListDto> GetAreaByIdAsync(EntityDto<int> input)
        {
            var entity = await _areaRepository.GetAsync(input.Id);

            return entity.MapTo<AreaListDto>();
        }







        /// <summary>
        /// 新增或更改区域管理
        /// </summary>
        public async Task CreateOrUpdateAreaAsync(CreateOrUpdateAreaInput input)
        {
            if (input.AreaEditDto.Id.HasValue)
            {
                await UpdateAreaAsync(input.AreaEditDto);
            }
            else
            {
                await CreateAreaAsync(input.AreaEditDto);
            }
        }

        /// <summary>
        /// 新增区域管理
        /// </summary>
        protected virtual async Task<AreaEditDto> CreateAreaAsync(AreaEditDto input)
        {

            var entity = input.MapTo<Area>();

            entity = await _areaRepository.InsertAsync(entity);
            return entity.MapTo<AreaEditDto>();
        }

        /// <summary>
        /// 编辑区域管理
        /// </summary>
        protected virtual async Task UpdateAreaAsync(AreaEditDto input)
        {

            var entity = await _areaRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _areaRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除区域管理
        /// </summary>
        public async Task DeleteAreaAsync(EntityDto<int> input)
        {
            await _areaRepository.DeleteAsync(input.Id);
        }

        #endregion










    }
}
