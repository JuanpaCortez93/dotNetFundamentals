using _004_Example5_Complete.DTOs.Teachers;
using _004_Example5_Complete.Models;
using _004_Example5_Complete.Services.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        private ICommonService<TeachersGetDTO, TeachersPostDTO, TeachersPutDTO> _teachersService;
        private IValidator<TeachersPostDTO> _teachersPostValidator;
        private IValidator<TeachersPutDTO> _teachersPutValidator;

        public TeachersController 
            (
                [FromKeyedServices("TeachersServices")]ICommonService<TeachersGetDTO, TeachersPostDTO, TeachersPutDTO> teachersService,
                IValidator<TeachersPostDTO> teachersPostValidator,
                IValidator<TeachersPutDTO> teachersPutValidator
            )
        {
            _teachersService = teachersService;
            _teachersPostValidator = teachersPostValidator;
            _teachersPutValidator = teachersPutValidator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachersGetDTO>>> GetTeachers() => Ok(await _teachersService.GetElements());

        [HttpGet("id/{id}")]
        public async Task<ActionResult<TeachersGetDTO>> GetTeacher(Guid id) {
            var teacherDTO = await _teachersService.GetElement(id);
            return teacherDTO == null ? NotFound() : Ok(teacherDTO);
        }


        [HttpPost]
        public async Task<ActionResult<TeachersGetDTO>> AddTeacher(TeachersPostDTO teachersPostDTO)
        {

            var validatorResult = await _teachersPostValidator.ValidateAsync(teachersPostDTO);
            if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);

            var teacherDTO = await _teachersService.AddElement(teachersPostDTO);
            return CreatedAtAction(nameof(GetTeacher), new { Id = teacherDTO.Id }, teacherDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeachersGetDTO>> UpdateTeacher(Guid id, TeachersPutDTO teachersPutDTO)
        {

            var validationResult = await _teachersPutValidator.ValidateAsync(teachersPutDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var teacherDTO = await _teachersService.UpdateElement(id, teachersPutDTO);
            return teacherDTO == null ? NotFound() : Ok(teacherDTO);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TeachersGetDTO>> DeleteTeacher(Guid id)
        {

            var teacherDTO = await _teachersService.DeleteElement(id);
            return teacherDTO == null ? NotFound() : Ok(teacherDTO);

        }


    }
}
