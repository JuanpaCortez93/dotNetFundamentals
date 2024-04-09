using _004_Example3.Context;
using _004_Example3.DTOs.Patients;
using _004_Example3.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _004_Example3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        //Variables
        private PatientsDatabaseContext _patientsDatabaseContext;
        private IValidator<PatientsPostDTO> _patientsPostValidator;
        private IValidator<PatientsPutDTO> _patientsPutValidator;

        //Constructor
        public PatientsController (PatientsDatabaseContext patientsDatabaseContext, IValidator<PatientsPostDTO> patientsPostValidator, IValidator<PatientsPutDTO> patientsPutValidator) 
        {
            _patientsDatabaseContext = patientsDatabaseContext;
            _patientsPostValidator = patientsPostValidator;
            _patientsPutValidator = patientsPutValidator;
        }


        //Methods
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PatientsGetDTO>>> GetPatients()
        {

            var patients = await _patientsDatabaseContext.Patients.Select(patient => new PatientsGetDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthday = patient.Birthday,
                Address = patient.Address,
                Telephone = patient.Telephone
            }).ToListAsync();

            return Ok(patients);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<PatientsGetDTO>>> GetPatientByName(string name)
        {

            var patients = _patientsDatabaseContext.Patients.Where(patient => patient.FirstName.ToUpper().Contains(name.ToUpper()));

            var patientsDTO = patients.Select(patient => new PatientsGetDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthday = patient.Birthday,
                Address = patient.Address,
                Telephone = patient.Telephone
            });

            return Ok(patientsDTO);

        }


        [HttpGet("id/{id}")]
        public async Task<ActionResult<PatientsGetDTO>> GetPatientById(int id)
        {
            var patient = _patientsDatabaseContext.Patients.Find(id);

            if (patient == null) return NoContent();

            var patientDTO = new PatientsGetDTO { 
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthday = patient.Birthday,
                Address = patient.Address,
                Telephone = patient.Telephone
            };

            return Ok(patientDTO);
        }


        [HttpPost("add")]
        public async Task<ActionResult<PatientsGetDTO>> AddPatient(PatientsPostDTO patientsPostDTO)
        {

            var validationResult = await _patientsPostValidator.ValidateAsync(patientsPostDTO);

            if(!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var patient = new Patients()
            {
                FirstName = patientsPostDTO.FirstName,
                LastName = patientsPostDTO.LastName,
                Birthday = patientsPostDTO.Birthday,
                Address = patientsPostDTO.Address,
                Telephone = patientsPostDTO.Telephone
            };

            await _patientsDatabaseContext.Patients.AddAsync(patient);
            _patientsDatabaseContext.SaveChanges();

            var patientDTO = new PatientsGetDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthday = patient.Birthday,
                Address = patient.Address,
                Telephone = patient.Telephone
            };

            return CreatedAtAction(nameof(GetPatientById), new {Id = patientDTO.Id}, patientDTO);

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<PatientsGetDTO>> UpdatePatient(int id, PatientsPutDTO patientsPutDTO)
        {

            var validationResult = await _patientsPutValidator.ValidateAsync(patientsPutDTO);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var patient = await _patientsDatabaseContext.Patients.FindAsync(id);
            if (patient == null) NotFound();

            patient.FirstName = patientsPutDTO.FirstName;
            patient.LastName = patientsPutDTO.LastName;
            patient.Birthday = patientsPutDTO.Birthday;
            patient.Address = patientsPutDTO.Address;
            patient.Telephone = patientsPutDTO.Telephone;

            _patientsDatabaseContext.Update(patient);
            _patientsDatabaseContext.SaveChanges();

            var patientGetDTO = new PatientsGetDTO
            {
                Id = id,
                FirstName = patientsPutDTO.FirstName,
                LastName = patientsPutDTO.LastName,
                Birthday = patientsPutDTO.Birthday,
                Address = patientsPutDTO.Address,
                Telephone = patientsPutDTO.Telephone
            };

            return CreatedAtAction(nameof(GetPatientById), new { Id = patientGetDTO.Id }, patientGetDTO);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _patientsDatabaseContext.Patients.FindAsync(id);
            if (patient == null) return NoContent();

            _patientsDatabaseContext.Remove(patient);
            _patientsDatabaseContext.SaveChanges();

            return NoContent();

        }

    }
}
