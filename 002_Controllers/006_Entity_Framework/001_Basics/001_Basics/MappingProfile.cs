using _001_Basics.DTOs;
using _001_Basics.Models;
using AutoMapper;

namespace _001_Basics
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<BeerInsertDTO, BeerModels>();
            CreateMap<BeerModels, BeerDTO>().ForMember(dto => dto.Id, mapping => mapping.MapFrom(beer => beer.Id));
            CreateMap<BeerUpdateDTO, BeerModels>();
        }
    }
}
