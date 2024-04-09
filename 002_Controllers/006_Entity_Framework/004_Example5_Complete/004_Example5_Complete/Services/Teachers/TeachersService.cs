using _004_Example5_Complete.DTOs.Teachers;
using _004_Example5_Complete.Models;
using _004_Example5_Complete.Repositories;
using _004_Example5_Complete.Services.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Services.Teachers
{
    public class TeachersService : ICommonService<TeachersGetDTO, TeachersPostDTO, TeachersPutDTO>
    {

        private IMapper _mapper;
        private IRepository<_004_Example5_Complete.Models.Teachers> _teachersRepository;

        public TeachersService
            (
                IRepository<_004_Example5_Complete.Models.Teachers> teachersRepository,
                IMapper mapper
            ) 
        {
            _teachersRepository = teachersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeachersGetDTO>> GetElements()
        {
            var teachers = await _teachersRepository.GetValues();
            var teachersDTO = teachers.Select(teacher => _mapper.Map<TeachersGetDTO>(teacher));

            return teachersDTO;
        }

        public async Task<TeachersGetDTO> GetElement(Guid id)
        {
            var teacher = await _teachersRepository.GetValue(id);
            if (teacher == null) return null;

            var teacherDTO = _mapper.Map<TeachersGetDTO>(teacher);

            return teacherDTO;
        }

        public async Task<TeachersGetDTO> AddElement(TeachersPostDTO tPostDTO)
        {
            var teacher = _mapper.Map<_004_Example5_Complete.Models.Teachers>(tPostDTO);

            await _teachersRepository.AddValue(teacher);
            await _teachersRepository.Save();

            var teacherDTO = _mapper.Map<TeachersGetDTO>(teacher);

            return teacherDTO;
        }

        public async Task<TeachersGetDTO> UpdateElement(Guid id, TeachersPutDTO tPutDTO)
        {

            var teacher = await _teachersRepository.GetValue(id);
            if (teacher == null) return null;

            teacher = _mapper.Map<TeachersPutDTO, _004_Example5_Complete.Models.Teachers>(tPutDTO, teacher);

            _teachersRepository.Update(teacher);
            await _teachersRepository.Save();

            var teacherDTO = _mapper.Map<TeachersGetDTO>(teacher);

            return teacherDTO;
        }

        public async Task<TeachersGetDTO> DeleteElement(Guid id)
        {
            var teacher = await _teachersRepository.GetValue(id);
            if (teacher == null) return null;

            _teachersRepository.Delete(teacher);
            await _teachersRepository.Save();

            var teacherDTO = _mapper.Map<TeachersGetDTO>(teacher);

            return teacherDTO;
        }
    }
}
