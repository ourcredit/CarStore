using System.Configuration;
using AutoMapper;
using YT.Authorization.Users.Dto;
using YT.Dashboard.Areas.Dtos;
using YT.Dashboard.WareHouses.Dtos;
using YT.Managers.Users;
using YT.Models;

namespace YT
{
    /// <summary>
    /// dto”≥…‰≈‰÷√Œƒº˛
    /// </summary>
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();
        private static readonly string Host = ConfigurationManager.AppSettings.Get("WebSiteRootAddress");
        public static void CreateMappings(IMapperConfigurationExpression mapper)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(mapper);

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());

            mapper.CreateMap<Area, AreaListDto>()
                .ForMember(c => c.ParentName, o => o.MapFrom(w => w.Parent.AreaName));
            mapper.CreateMap<WareHouse, WareHouseListDto>()
                .ForMember(c => c.AreaName, o => o.MapFrom(w => w.Area.AreaName));
        }
    }
}