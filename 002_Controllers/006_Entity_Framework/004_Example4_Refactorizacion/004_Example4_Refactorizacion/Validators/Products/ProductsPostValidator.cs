using _004_Example4_Refactorizacion.DTOs.Products;
using FluentValidation;

namespace _004_Example4_Refactorizacion.Validators.Products
{
    public class ProductsPostValidator : AbstractValidator<ProductsPostDTO>
    {
        public ProductsPostValidator() 
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Not empty values");
            RuleFor(product => product.Name).NotNull().WithMessage("Not null values");
            RuleFor(product => product.Name).Length(3, 50).WithMessage("The name must be between 3 and 50 characters");

            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Value must be greater than zero");
            RuleFor(product => product.Amount).GreaterThan(0).WithMessage("Value must be greater than zero");
        }
    }
}
