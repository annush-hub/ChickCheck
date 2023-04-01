using Application.Barns.Dtos;
using Application.EggGrades;
using Application.Feeders;
using Application.Storages;
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
                o => o.MapFrom(src => src.Barns.ToList()))
                .ForMember(d => d.Storages,
                o => o.MapFrom(src => src.Storages.ToList()));

            CreateMap<Feeder, FeederDto>()
                .ForMember(d => d.BarnId, o => o.MapFrom(src => src.Barn.Id));

            CreateMap<FeederDto, Feeder>()
                .ForMember(d => d.Capacity, o => o.MapFrom(src => src.Capacity))
                .ForMember(d => d.Fullness, o => o.MapFrom(src => src.Fullness))
                .ForMember(d => d.IsInUse, o => o.MapFrom(src => src.IsInUse))
                .ForMember(d => d.BarnId, o => o.MapFrom(src => src.BarnId));

            CreateMap<EggGradeStorage, EggGradeShortDto>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.EggGradeId))
                .ForMember(d => d.GradeUA, o => o.MapFrom(src => src.EggGrade.GradeUA))
                .ForMember(d => d.GradeEU, o => o.MapFrom(src => src.EggGrade.GradeEU));

            CreateMap<EggGradeStorage, StorageDto>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.StorageId))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.Storage.Name))
                .ForMember(d => d.City, o => o.MapFrom(src => src.Storage.City))
                .ForMember(d => d.Region, o => o.MapFrom(src => src.Storage.Region))
                .ForMember(d => d.IsWorking, o => o.MapFrom(src => src.Storage.IsWorking));

            CreateMap<StorageDto, Storage>();

            CreateMap<Storage, StorageDetailedDto>()
                .ForMember(d => d.EggGrades,
                o => o.MapFrom(src => src.EggGrades.ToList()));

            CreateMap<EggGardeStorageDto, EggGradeStorage>();

            CreateMap<Cleaning, BarnCleaningDto>()
               .ForMember(d => d.User, o => o.MapFrom(src => src.AppUser.DisplayName))
               .ForMember(d => d.CleanedAt, o => o.MapFrom(src => TimeAdapter.unixToDt(src.CleanedAt)));
        }  
    }
}
