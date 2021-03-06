﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YT.Dashboard.Areas.Dtos;
using YT.Dashboard.Products.Dtos;

namespace YT.Dashboard.Areas
{
	/// <summary>
    /// 区域管理服务接口
    /// </summary>
    public interface IAreaAppService : IApplicationService
    {
        #region 区域管理管理

        /// <summary>
        /// 根据查询条件获取区域管理分页列表
        /// </summary>
        Task<PagedResultDto<AreaListDto>> GetPagedAreasAsync(GetAreaInput input);

        /// <summary>
        /// 通过Id获取区域管理信息进行编辑或修改 
        /// </summary>
        Task<GetAreaForEditOutput> GetAreaForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取区域管理ListDto信息
        /// </summary>
		Task<AreaListDto> GetAreaByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 更新区域商品价格
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAreaPrices(UpdateAreaPriceInput input);
        /// <summary>
        /// 获取商品价格定义
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<AreaProductDto>> GetAreaProductsAsync(EntityDto input);
        /// <summary>
        /// 获取所有区域对象
        /// </summary>
        /// <returns></returns>
        Task<List<AreaListDto>> GetAllAreas();

        /// <summary>
        /// 新增或更改区域管理
        /// </summary>
        Task CreateOrUpdateAreaAsync(CreateOrUpdateAreaInput input);


        /// <summary>
        /// 删除区域管理
        /// </summary>
        Task DeleteAreaAsync(EntityDto<int> input);

        #endregion




    }
}
