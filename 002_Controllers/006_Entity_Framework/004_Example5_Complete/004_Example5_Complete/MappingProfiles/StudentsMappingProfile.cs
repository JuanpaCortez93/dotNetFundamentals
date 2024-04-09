using _004_Example5_Complete.DTOs.Students;
using _004_Example5_Complete.Models;
using AutoMapper;

namespace _004_Example5_Complete.MappingProfiles
{
    public class StudentsMappingProfile : Profile
    {
        public StudentsMappingProfile() 
        {
            CreateMap<Students, StudentsGetDTO>();
            CreateMap<StudentsPostDTO, Students>();
            CreateMap<StudentsPutDTO, Students>();
        }
    }
}
