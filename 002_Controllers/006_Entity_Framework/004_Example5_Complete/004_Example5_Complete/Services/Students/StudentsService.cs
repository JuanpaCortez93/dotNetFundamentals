using _004_Example5_Complete.DTOs.Students;
using _004_Example5_Complete.Models;
using _004_Example5_Complete.Repositories;
using _004_Example5_Complete.SchoolDbContext;
using _004_Example5_Complete.Services.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Services.Students
{
    public class StudentsService : ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO>
    {

        private _004_Example5_Complete.SchoolDbContext.SchoolDbContext _schoolDbContext;
        private IMapper _studentsMappingProfile;
        private IRepository<_004_Example5_Complete.Models.Students> _repositoryStudents;

        public StudentsService(
                _004_Example5_Complete.SchoolDbContext.SchoolDbContext schoolDbContext,
                IRepository<_004_Example5_Complete.Models.Students> repositoryStudents,
                IMapper studentsMappingProfile
            )
        {
            _schoolDbContext = schoolDbContext;
            _repositoryStudents = repositoryStudents;
            _studentsMappingProfile = studentsMappingProfile;
        }

        public async Task<IEnumerable<StudentsGetDTO>> GetElements()
        {
            var students = await _repositoryStudents.GetValues();
            var studentsDTO = students.Select(student => _studentsMappingProfile.Map<StudentsGetDTO>(student));
            return studentsDTO;
        }

        public async Task<StudentsGetDTO> GetElement(Guid id)
        {
            var student = await _repositoryStudents.GetValue(id);
            if (student == null) return null;
            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);

            return studentDTO;
        }

        public async Task<StudentsGetDTO> AddElement(StudentsPostDTO tPostDTO)
        {
            var student = _studentsMappingProfile.Map<_004_Example5_Complete.Models.Students>(tPostDTO);

            await _repositoryStudents.AddValue(student);
            await _repositoryStudents.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);

            return studentDTO;
        }

        public async Task<StudentsGetDTO> UpdateElement(Guid id, StudentsPutDTO tPutDTO)
        {
            var student = await _schoolDbContext.Students.FindAsync(id);
            if (student == null) return null;
            student = _studentsMappingProfile.Map<StudentsPutDTO, _004_Example5_Complete.Models.Students>(tPutDTO, student);

            _repositoryStudents.Update(student);
            await _repositoryStudents.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);
            return studentDTO;
        }

        public async Task<StudentsGetDTO> DeleteElement(Guid id)
        {
            var student = await _repositoryStudents.GetValue(id);
            if (student == null) return null;

            _repositoryStudents.Delete(student);
            await _repositoryStudents.Save();

            var studentDTO = _studentsMappingProfile.Map<StudentsGetDTO>(student);
            return studentDTO;
        }




    }
}
