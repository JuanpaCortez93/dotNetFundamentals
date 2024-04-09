using _003_Example2.Context;
using _003_Example2.DTOs;
using _003_Example2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _003_Example2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private DoctorsContext _doctorsContext;

        public DoctorsController(DoctorsContext doctorsContext) => _doctorsContext = doctorsContext;

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DoctorsGetDTO>>> GetDoctors([FromHeader] string Host)
        {
            Console.WriteLine($"Getting data from {Host}");

            var doctors = _doctorsContext.Doctors.Select(doctor => new DoctorsGetDTO
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty
            });

            return Ok(doctors);

        }

        [HttpGet("individual/{id}")]
        public async Task<ActionResult<DoctorsGetDTO>> GetDoctor(int id, [FromHeader] string Host)
        {
            Console.WriteLine($"Getting data from {Host}");

            var doctor = await _doctorsContext.Doctors.FindAsync(id);

            if (doctor == null) return NotFound();

            var doctorDTO = new DoctorsGetDTO { Id = id, FirstName = doctor.FirstName, LastName = doctor.LastName, Specialty = doctor.Specialty };

            return Ok(doctorDTO);
        }

        [HttpPost("add")]
        public async Task<ActionResult<DoctorsGetDTO>> AddDoctor(DoctorsPostDTO doctorsPostDTO, [FromHeader] string Host)
        {

            var newDoctor = new Doctors()
            {
                FirstName = doctorsPostDTO.FirstName,
                LastName = doctorsPostDTO.LastName,
                Specialty = doctorsPostDTO.Specialty
            };

            await _doctorsContext.AddAsync(newDoctor);
            _doctorsContext.SaveChanges();

            var doctorsGetDTO = new DoctorsGetDTO
            {
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Specialty = newDoctor.Specialty
            };

            return CreatedAtAction(nameof(GetDoctor), new { Id = newDoctor.Id }, doctorsGetDTO);

        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<DoctorsGetDTO>> UpdateDoctor(int id, DoctorsPutDTO doctorsPutDTO)
        {

            var doctor = await _doctorsContext.Doctors.FindAsync(id);

            if (doctor == null) return NoContent();

            doctor.FirstName = doctorsPutDTO.FirstName;
            doctor.LastName = doctorsPutDTO.LastName;
            doctor.Specialty = doctorsPutDTO.Specialty;

            _doctorsContext.Update(doctor);
            _doctorsContext.SaveChanges();

            var doctorGetDTO = new DoctorsGetDTO
            {
                FirstName = doctorsPutDTO.FirstName,
                LastName = doctorsPutDTO.LastName,
                Specialty = doctorsPutDTO.Specialty
            };

            return CreatedAtAction(nameof(GetDoctor), new { Id = doctor.Id }, doctorGetDTO);

        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorsContext.Doctors.FindAsync(id);

            if (doctor == null) return NotFound();

            _doctorsContext.Remove(doctor);
            _doctorsContext.SaveChanges();

            return Ok();
        }


    }
}
