using _001_Basics.DTOs;
using _001_Basics.Models;
using _001_Basics.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _001_Basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO> _beerService;
        private IValidator<BeerInsertDTO> _beerInsertValidator;
        private IValidator<BeerUpdateDTO> _beerUpdateValidator;

        public BeerController( 
                              IValidator<BeerInsertDTO> beerInsertValidator,
                              IValidator<BeerUpdateDTO> beerUpdateValidator,
                              [FromKeyedServices("BeerService")]ICommonService<BeerDTO, BeerInsertDTO, BeerUpdateDTO> beerService
                              )
        {
            _beerService = beerService;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<BeerDTO>> GetBeers() => await _beerService.GetBeers();

        [HttpGet("id/{id}")]
        public async Task<ActionResult<BeerDTO>> GetBeer(int id)
        {
            var beerDTO = await _beerService.GetBeer(id);
            return beerDTO == null ? NotFound() : Ok(beerDTO);
        }


        [HttpPost]
        public async Task<ActionResult<BeerDTO>> AddBeer(BeerInsertDTO beerInsertDTO)
        {

            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDTO);

            if(!validationResult.IsValid) return BadRequest(validationResult.Errors);

            if (!_beerService.Validate(beerInsertDTO)) return BadRequest(_beerService.Errors);

            var beerDTO = await _beerService.AddBeer(beerInsertDTO);

            return CreatedAtAction(nameof(GetBeer), new { id = beerDTO.Id }, beerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDTO>> UpdateBeer(int id, BeerUpdateDTO beerUpdateDTO)
        {

            var validatorResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDTO);

            if (!validatorResult.IsValid) return BadRequest(validatorResult.Errors);

            if(!_beerService.Validate()) return BadRequest(_beerService.Errors);

            var beerDTO = await _beerService.UpdateBeer(id, beerUpdateDTO);

            return beerDTO == null ? NotFound() : Ok(beerDTO);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDTO>> DeleteBeer(int id)
        {
            var beerDTO = await _beerService.DeleteBeer(id);
            return beerDTO == null ? NotFound() : Ok(beerDTO);
        }



    }
}
