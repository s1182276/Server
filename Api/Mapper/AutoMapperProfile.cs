using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerCore.Models;

namespace KeuzeWijzerApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SchoolModule, SchoolModuleDto>().ReverseMap()
                // We also need to mapp the Schoolyear to the SchoolModule
                .ForMember(dest => dest.SchoolYear, mem => mem.MapFrom(map => map.SchoolYear));
            CreateMap<SchoolYear, SchoolYearDto>().ReverseMap()
                .ForMember(dest => dest.SchoolModules, mem => mem.MapFrom(map => map.SchoolModules));
        }
    }
}
