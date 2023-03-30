using Application.Barns;
using Application.EggGrades;
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
                .ForMember(d => d.EggGradeUA, o => o.MapFrom(src => src.EggGrade.GradeUA));

            CreateMap<EggGrade, EggGradeDto>()
                .ForMember(d => d.Barns,
                o => o.MapFrom(src => src.Barns.ToList()));
              
        }
    }
}
