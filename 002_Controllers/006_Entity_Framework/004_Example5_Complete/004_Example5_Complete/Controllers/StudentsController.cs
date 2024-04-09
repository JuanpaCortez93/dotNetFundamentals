using _004_Example5_Complete.DTOs.Students;
using _004_Example5_Complete.Models;
using _004_Example5_Complete.SchoolDbContext;
using _004_Example5_Complete.Services.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private IValidator<StudentsPostDTO> _studentsPostFormatValidator;
        private IValidator<StudentsPutDTO> _studentsPutFormatValidator;
        private ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO> _studentsServices;


        public StudentsController(
            IValidator<StudentsPostDTO> studentsPostFormatValidator,
            IValidator<StudentsPutDTO> studentsPutFormatValidator,
            [FromKeyedServices("StudentsServices")]ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO> studentsServices
            )
        {
            _studentsPostFormatValidator = studentsPostFormatValidator;
            _studentsPutFormatValidator = studentsPutFormatValidator;
            _studentsServices = studentsServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsGetDTO>>> GetStudents() => Ok(await _studentsServices.GetElements());

        [HttpGet("id/{id}")]
        public async Task<ActionResult<StudentsGetDTO>> GetStudent(Guid id)
        {
            var studentDTO = await _studentsServices.GetElement(id);
            return studentDTO == null ? NotFound() : Ok(studentDTO);
        }

        [HttpPost]
        public async Task<ActionResult<StudentsGetDTO>> AddStudent(StudentsPostDTO studentsPostDTO)
        {

            var validationFormatResult = await _studentsPostFormatValidator.ValidateAsync(studentsPostDTO);
            if (!validationFormatResult.IsValid) return BadRequest(validationFormatResult.Errors);

            var studentDTO = await _studentsServices.AddElement(studentsPostDTO);

            return CreatedAtAction(nameof(GetStudent), new { Id = studentDTO.Id}, studentDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentsGetDTO>> UpdateStudent(Guid id, StudentsPutDTO studentsPutDTO)
        {

            var validationFormatResult = await _studentsPutFormatValidator.ValidateAsync(studentsPutDTO);
            if (!validationFormatResult.IsValid) return BadRequest(validationFormatResult.Errors);

            var studentDTO = await _studentsServices.UpdateElement(id, studentsPutDTO);

            return studentDTO == null ? NotFound() : Ok(studentDTO);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsGetDTO>> DeleteStudent(Guid id)
        {

            var studentDTO = await _studentsServices.DeleteElement(id);
            return studentDTO == null ? NotFound() : Ok(studentDTO);

        }





    }


}
