using Application.Barns;
using Application.Barns.Dtos;
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

            CreateMap<UpdateBarnDto, Barn>()
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.Description, o => o.MapFrom(src => src.Description))
                .ForMember(d => d.Description, o => o.MapFrom(src => src.Description))
                .ForMember(d => d.TemperatureInCelsius, o => o.MapFrom(src => src.TemperatureInCelsius))
                .ForMember(d => d.TemperatureInFahrenheit, o => o.MapFrom(src => src.TemperatureInFahrenheit))
                .ForMember(d => d.IsDeactivated, o => o.MapFrom(src => src.IsDeactivated))
                .ForMember(d => d.EggGradeId, o => o.MapFrom(src => src.EggGradeId));

            //    .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
            //    .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
            //    .ForMember(d => d.Image, o => o.MapFrom(S => S.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

            //CreateMap<ActivityAttendee, AttendeeDto>()
            //    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
            //    .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
            //    .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
            //    .ForMember(d => d.Image, o => o.MapFrom(S => S.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));

        }
    }
}
