using _004_Example4_Refactorizacion.DatabaseContext;
using _004_Example4_Refactorizacion.DTOs.Clients;
using _004_Example4_Refactorizacion.Model;
using _004_Example4_Refactorizacion.Services.Clients;
using _004_Example4_Refactorizacion.Services.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace _004_Example4_Refactorizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private EShopDbContext _eShopDbContext;
        private IValidator<ClientsPostDTO> _clientPostValidator;
        private IValidator<ClientsPutDTO> _clientsPutValidator;
        private ICommonService<ClientsGetDTO, ClientsPostDTO, ClientsPutDTO> _clientsService;

        public ClientsController(
                                EShopDbContext eShopDbContext,
                                IValidator<ClientsPostDTO> clientPostValidator,
                                IValidator<ClientsPutDTO> clientPutValidator,
                                [FromKeyedServices("ClientsService")] ICommonService<ClientsGetDTO, ClientsPostDTO, ClientsPutDTO> clientsService
                                )
        {
            _eShopDbContext = eShopDbContext;
            _clientPostValidator = clientPostValidator;
            _clientsPutValidator = clientPutValidator;
            _clientsService = clientsService;
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ClientsGetDTO>>> GetClients()
        {
            var clientsDTO = await _clientsService.GetElements();
            return Ok(clientsDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ClientsGetDTO>> GetClientById(Guid id)
        {

            var clientDTO = await _clientsService.GetElementById(id);
            return clientDTO == null ? NotFound() : Ok(clientDTO);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<ClientsGetDTO>> GetClientByName(string name)
        {

            var clientsDTO = _clientsService.GetElementByName(name);
            return clientsDTO == null ? NotFound() : Ok(clientsDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ClientsGetDTO>> AddClient(ClientsPostDTO clientsPostDTO)
        {

            var clientsValidatorResult = await _clientPostValidator.ValidateAsync(clientsPostDTO);
            if (!clientsValidatorResult.IsValid) return BadRequest(clientsValidatorResult.Errors);

            var clientDTO = await _clientsService.AddElement(clientsPostDTO);

            return CreatedAtAction(nameof(GetClientById), new {Id = clientDTO.Id}, clientDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientsGetDTO>> UpdateClient(Guid id, ClientsPutDTO clientsPutDTO)
        {

            var clientsValidatorResult = await _clientsPutValidator.ValidateAsync(clientsPutDTO);
            if (!clientsValidatorResult.IsValid) return BadRequest(clientsValidatorResult.Errors);

            var clientDTO = await _clientsService.UpdateElement(id, clientsPutDTO);

            return clientDTO == null ? NotFound() : Ok(clientDTO);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientsGetDTO>> DeleteClient(Guid id)
        {
            var clientDTO = await _clientsService.DeleteElement(id);
            return clientDTO == null ? NotFound() : Ok(clientDTO);
        }

    }
}
