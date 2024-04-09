using _004_Example5_Complete.DTOs.Teachers;
using _004_Example5_Complete.Models;
using AutoMapper;

namespace _004_Example5_Complete.MappingProfiles
{
    public class TeachersMappingProfile : Profile
    {
        public TeachersMappingProfile() 
        {
            CreateMap<Teachers, TeachersGetDTO>();
            CreateMap<TeachersPostDTO, Teachers>();
            CreateMap<TeachersPutDTO, Teachers>();
        }
    }
}
