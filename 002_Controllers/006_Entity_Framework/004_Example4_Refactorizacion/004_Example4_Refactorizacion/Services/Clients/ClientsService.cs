using _004_Example4_Refactorizacion.DatabaseContext;
using _004_Example4_Refactorizacion.DTOs.Clients;
using _004_Example4_Refactorizacion.Model;
using _004_Example4_Refactorizacion.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace _004_Example4_Refactorizacion.Services.Clients
{
    public class ClientsService : ICommonService <ClientsGetDTO, ClientsPostDTO, ClientsPutDTO>
    {
        //Propierties
        private EShopDbContext _eShopDbContext;

        //Constructor
        public ClientsService(
            EShopDbContext eShopDbContext
            ) 
        {
            _eShopDbContext = eShopDbContext;
        }

        //Methods
        public async Task<IEnumerable<ClientsGetDTO>> GetElements() => await _eShopDbContext.Clients.Select(client => new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            }).ToListAsync();

        public async Task<ClientsGetDTO> GetElementById(Guid id)
        {
            var client = await _eShopDbContext.Clients.FindAsync(id);

            if (client == null) return null;

            var clientDTO = new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            };

            return clientDTO;
        }

        public IEnumerable<ClientsGetDTO> GetElementByName(string name)
        {

            var clients = _eShopDbContext.Clients.Where(client => client.FirstName.ToUpper().Contains(name.ToUpper()));

            if (clients == null) return null;

            var clientsDTO = clients.Select(client => new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            }).ToList();

            return clientsDTO;
        }

        public async Task<ClientsGetDTO> AddElement(ClientsPostDTO clientsPostDTO)
        {

            var client = new _004_Example4_Refactorizacion.Model.Clients()
            {
                FirstName = clientsPostDTO.FirstName,
                LastName = clientsPostDTO.LastName,
                Address = clientsPostDTO.Address,
                Email = clientsPostDTO.Email,
                Telephone = clientsPostDTO.Telephone
            };

            await _eShopDbContext.AddAsync(client);
            await _eShopDbContext.SaveChangesAsync();

            var clientDTO = new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            };

            return clientDTO;

        }

        public async Task<ClientsGetDTO> UpdateElement(Guid id, ClientsPutDTO clientsPutDTO)
        {

            var client = await _eShopDbContext.Clients.FindAsync(id);

            if (client == null) return null;

            client.FirstName = clientsPutDTO.FirstName;
            client.LastName = clientsPutDTO.LastName;
            client.Address = clientsPutDTO.Address;
            client.Email = clientsPutDTO.Email;
            client.Telephone = clientsPutDTO.Telephone;

            _eShopDbContext.Update(client);
            await _eShopDbContext.SaveChangesAsync();

            var clientDTO = new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            };

            return clientDTO;

        }

        public async Task<ClientsGetDTO> DeleteElement(Guid id)
        {
            var client = await _eShopDbContext.Clients.FindAsync(id);
            if (client == null) return null;

            _eShopDbContext.Remove(client);
            await _eShopDbContext.SaveChangesAsync();

            var clientDTO = new ClientsGetDTO
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Email = client.Email,
                Telephone = client.Telephone
            };

            return clientDTO;
        }
    }
}
