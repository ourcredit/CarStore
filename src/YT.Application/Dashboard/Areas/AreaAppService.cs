using System;
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
using YT.Dashboard.Areas.Dtos;
using YT.Dashboard.Products.Dtos;
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
        private readonly IRepository<AreaPrice, int> _areaPriceRepository;
        private readonly IRepository<Product, int> _productRepository;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="areaRepository"></param>
        /// <param name="areaPriceRepository"></param>
        /// <param name="productRepository"></param>
        public AreaAppService(IRepository<Area, int> areaRepository, IRepository<AreaPrice, int> areaPriceRepository, IRepository<Product, int> productRepository)
        {
            _areaRepository = areaRepository;
            _areaPriceRepository = areaPriceRepository;
            _productRepository = productRepository;
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
            var aps = await _areaPriceRepository.GetAllListAsync();

            var query = AreaRepositoryAsNoTrack;
            query = query.WhereIf(!input.Filter.IsNullOrWhiteSpace(), c => c.AreaName.Contains(input.Filter))
                .WhereIf(input.Level.HasValue, c => c.LevelCode.Length == input.Level.Value);
            var areaCount = await query.CountAsync();
            var areas = await query
            .OrderBy(input.Sorting)
            .PageBy(input)
            .ToListAsync();
            var result = new List<AreaListDto>();
            foreach (var area in areas)
            {
                var model = area.MapTo<AreaListDto>();
                model.State = aps.Count(c => c.AreaId == area.Id) > 0;
                result.Add(model);
            }

            return new PagedResultDto<AreaListDto>(
            areaCount,
            result
            );
        }
        /// <summary>
        /// 获取商品价格定义
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<AreaProductDto>> GetAreaProductsAsync(EntityDto input)
        {
            var products = _productRepository.GetAll();
            var prices = _areaPriceRepository.GetAll().Where(c => c.AreaId == input.Id);

            var temp = from c in await products.ToListAsync()
                       join d in await prices.ToListAsync()
                           on c.Id equals d.ProductId into h
                       from hh in h.DefaultIfEmpty()
                       select new AreaProductDto()
                       {
                           Id = (hh != null ? hh.Id : new int?()),
                           ProductId = c.Id,
                           ProductName = c.ProductName,
                           ProductNum = c.ProductNum,
                           Cost = hh != null ? hh.Cost : c.Cost,
                           Price = hh != null ? hh.Price : c.Price
                       };
            return temp.ToList();
        }
        /// <summary>
        /// 更新区域商品价格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAreaPrices(UpdateAreaPriceInput input)
        {
            var aps = await _areaPriceRepository.GetAllListAsync(c => c.AreaId == input.AreaId);
            foreach (var dto in input.List)
            {
                if (dto.Id.HasValue)
                {
                    var temp = aps.First(c => c.Id == dto.Id.Value);
                    if(temp.Cost==dto.Cost&&temp.Price==dto.Price)continue;
                    temp.Cost = dto.Cost;
                    temp.Price = dto.Price;
                }
                else
                {
                    await _areaPriceRepository.InsertAsync(new AreaPrice()
                    {
                        AreaId = input.AreaId,
                        Cost = dto.Cost,
                        Price = dto.Price,
                        ProductId = dto.ProductId
                    });
                }
            }
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
        /// 获取所有区域对象
        /// </summary>
        /// <returns></returns>
        public async Task<List<AreaListDto>> GetAllAreas()
        {
            var list = await AreaRepositoryAsNoTrack.ToListAsync();
            return list.MapTo<List<AreaListDto>>();
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
            if (input.ParentId.HasValue)
            {
                var parennt = await _areaRepository.FirstOrDefaultAsync(input.ParentId.Value);
                if (parennt != null)
                {
                    entity.LevelCode = $"{parennt.LevelCode}.{Guid.NewGuid().ToString("D").Split('-').Last()}";
                }
            }
            else
            {
                entity.LevelCode = $"{Guid.NewGuid().ToString("D").Split('-').Last()}";
            }
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
