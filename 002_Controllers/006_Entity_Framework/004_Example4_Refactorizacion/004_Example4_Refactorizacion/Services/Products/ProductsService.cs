using _004_Example4_Refactorizacion.DatabaseContext;
using _004_Example4_Refactorizacion.DTOs.Products;
using _004_Example4_Refactorizacion.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace _004_Example4_Refactorizacion.Services.Products
{
    public class ProductsService : ICommonService<ProductsGetDTO, ProductsPostDTO, ProductsPutDTO>
    {

        private EShopDbContext _eShopDbContext;

        public ProductsService(EShopDbContext eShopDbContext) 
        {
            _eShopDbContext = eShopDbContext;        
        }


        public async Task<IEnumerable<ProductsGetDTO>> GetElements()
        {

            var products = await _eShopDbContext.Products.Select(product => new ProductsGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            }).ToListAsync();

            return products;
        }

        public async Task<ProductsGetDTO> GetElementById(Guid id)
        {

            var product = await _eShopDbContext.Products.FindAsync(id);
            if (product == null) return null;

            var productDTO = new ProductsGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };

            return productDTO;

        }

        public IEnumerable<ProductsGetDTO> GetElementByName(string name)
        {
            var product = _eShopDbContext.Products.Where(product => product.Name.ToUpper().Contains(name.ToUpper()));
            if (product == null) return null;

            var productDTO = product.Select(product => new ProductsGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            });

            return productDTO;

        }


        public async Task<ProductsGetDTO> AddElement(ProductsPostDTO elementsPostDTO)
        {

            var product = new _004_Example4_Refactorizacion.Model.Products()
            {
                Name = elementsPostDTO.Name,
                Price = elementsPostDTO.Price,
                Amount = elementsPostDTO.Amount
            };

            await _eShopDbContext.Products.AddAsync(product);
            await _eShopDbContext.SaveChangesAsync();

            var productDTO = new ProductsGetDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = product.Amount
            };

            return productDTO;
        }

        public async Task<ProductsGetDTO> UpdateElement(Guid id, ProductsPutDTO elementsPutDTO)
        {

            var client = await _eShopDbContext.Products.FindAsync(id);
            if (client == null) return null;

            client.Name = elementsPutDTO.Name;
            client.Price = elementsPutDTO.Price;
            client.Amount = elementsPutDTO.Amount;

            _eShopDbContext.Update(client);
            await _eShopDbContext.SaveChangesAsync();

            var clientDTO = new ProductsGetDTO
            {
                Id = client.Id, 
                Name = client.Name,
                Price = client.Price,
                Amount = client.Amount
            };

            return clientDTO;
        }

        public async Task<ProductsGetDTO> DeleteElement(Guid id)
        {
            var product = await _eShopDbContext.Products.FindAsync(id);
            if (product == null) return null;

            _eShopDbContext.Remove(product);
            await _eShopDbContext.SaveChangesAsync();

            var productDTO = new ProductsGetDTO
            {
                Id = product.Id,
                Name= product.Name,
                Price = product.Price,
                Amount = product.Amount
            };

            return productDTO;
        }

    }
}
