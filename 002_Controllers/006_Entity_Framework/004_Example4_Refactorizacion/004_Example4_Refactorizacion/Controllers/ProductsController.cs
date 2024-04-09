using _004_Example4_Refactorizacion.DTOs.Products;
using _004_Example4_Refactorizacion.Services.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _004_Example4_Refactorizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IValidator<ProductsPostDTO> _productsPostValidator;
        private IValidator<ProductsPutDTO> _productsPutValidator;
        private ICommonService<ProductsGetDTO, ProductsPostDTO, ProductsPutDTO> _productsService;

        public ProductsController(
                IValidator<ProductsPostDTO> productsPostValidator,
                IValidator<ProductsPutDTO> productsPutValidator,
                [FromKeyedServices("ProductsService")] ICommonService<ProductsGetDTO, ProductsPostDTO, ProductsPutDTO> productsService
            )
        {
            _productsPostValidator = productsPostValidator;
            _productsPutValidator = productsPutValidator;
            _productsService = productsService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductsGetDTO>>> GetProducts()
        {
            var clientsDTO = await _productsService.GetElements();
            return Ok(clientsDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ProductsGetDTO>> GetProductById(Guid id)
        {
            var clientDTO = await _productsService.GetElementById(id);
            if (clientDTO == null) return NotFound();
            return Ok(clientDTO);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<ProductsGetDTO>> GetProductsByName(string name)
        {
            var clientsDTO = _productsService.GetElementByName(name);
            if (clientsDTO == null) return NotFound();
            return Ok(clientsDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductsGetDTO>> AddProduct(ProductsPostDTO productsPostDTO)
        {
            var productValidationResult = await _productsPostValidator.ValidateAsync(productsPostDTO);
            if (!productValidationResult.IsValid) return BadRequest(productValidationResult.Errors);

            var productDTO = await _productsService.AddElement(productsPostDTO);
            return CreatedAtAction(nameof(GetProductById), new { Id = productDTO.Id }, productDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductsGetDTO>> UpdateProduct(Guid id, ProductsPutDTO productsPutDTO)
        {
            var productValudationResult = await _productsPutValidator.ValidateAsync(productsPutDTO);
            if (!productValudationResult.IsValid) return BadRequest(productValudationResult.Errors);

            var productDTO = await _productsService.UpdateElement(id, productsPutDTO);
            return productDTO == null ? NotFound() : Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsGetDTO>> DeleteProduct(Guid id)
        {
            var productDTO = await _productsService.DeleteElement(id);
            if(productDTO == null) return NotFound();
            return Ok(productDTO);
        }


    }
}
