using AutoMapper;
using OpenBreweryASP.Models.Dtos;
using OpenBreweryASP.Models.Entities;

namespace OpenBreweryASP.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brewery, BreweryDto>().ReverseMap();
        }
    }
}