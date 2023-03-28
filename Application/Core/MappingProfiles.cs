
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
        }
    }
}
