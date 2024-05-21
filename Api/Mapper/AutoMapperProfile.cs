using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerCore.Models;

namespace KeuzeWijzerApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<LearningRoute, LearningRouteDto>().ReverseMap();
            CreateMap<LearningYear, LearningYearDto>().ReverseMap();
        }
    }
}
