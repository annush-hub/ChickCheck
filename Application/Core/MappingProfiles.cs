using Application.Barns.Dtos;
using Application.EggGrades;
using Application.Feeders;
using AutoMapper;
using Domain;
using System.Diagnostics;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Barn, Barn>();

            CreateMap<Barn, BarnDto>()
                .ForMember(d => d.EggGradeEU, o => o.MapFrom(src => src.EggGrade.GradeEU))
                .ForMember(d => d.EggGradeUA, o => o.MapFrom(src => src.EggGrade.GradeUA))
                .ForMember(d => d.Feeders,
                o => o.MapFrom(src => src.Feeders.ToList()));

            CreateMap<Barn, BarnShortDto>();

            CreateMap<EggGrade, EggGradeDto>()
                .ForMember(d => d.Barns,
                o => o.MapFrom(src => src.Barns.ToList()));

            CreateMap<Feeder, FeederDto>()
                .ForMember(d => d.BarnId, o => o.MapFrom(src => src.Barn.Id));

            CreateMap<FeederDto, Feeder>()
                .ForMember(d => d.Capacity, o => o.MapFrom(src => src.Capacity))
                .ForMember(d => d.Fullness, o => o.MapFrom(src => src.Fullness))
                .ForMember(d => d.IsInUse, o => o.MapFrom(src => src.IsInUse))
                .ForMember(d => d.BarnId, o => o.MapFrom(src => src.BarnId));
        }
    }
}
