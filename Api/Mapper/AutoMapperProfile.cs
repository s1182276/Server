using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerCore.Models;

namespace KeuzeWijzerApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SchoolModule, SchoolModuleDto>()
                .ReverseMap()
                .ForMember(dest => dest.SchoolYear, opt => opt.MapFrom(src => src.SchoolYear))
                .ForMember(dest => dest.EntryRequirementModules, opt => opt.MapFrom(src => src.EntryRequirementModules));


            CreateMap<SchoolYear, SchoolYearDto>()
                .ReverseMap()
                .ForMember(dest => dest.SchoolModules, mem => mem.MapFrom(map => map.SchoolModules));


            CreateMap<AppUser, AppUserDto>()
                .ReverseMap();

            CreateMap<EntryRequirementModule, EntryRequirementModuleDto>().ReverseMap();

            CreateMap<Studyroute, StudyrouteDto>()
                .ReverseMap()
                .ForMember(dest => dest.StudyrouteSemesters, opt => opt.MapFrom(src => src.StudyrouteSemesters));

            CreateMap<StudyrouteSemester, StudyrouteSemesterDto>()
                .ReverseMap()
            .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.ModuleId))
            .ForMember(dest => dest.SchoolYearId, opt => opt.MapFrom(src => src.SchoolYearId));
        }
    }
}
