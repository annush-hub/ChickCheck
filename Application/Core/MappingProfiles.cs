
using Application.Barns;
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
        }
    }
}
