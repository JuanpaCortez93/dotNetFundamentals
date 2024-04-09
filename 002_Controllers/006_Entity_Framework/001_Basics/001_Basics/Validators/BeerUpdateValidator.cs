using _001_Basics.DTOs;
using FluentValidation;

namespace _001_Basics.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDTO>
    {
        public BeerUpdateValidator() {
            RuleFor(x => x.Id).NotNull().WithMessage("El Id!! No comiences!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("No seas bruto, las cervezas llevan nombres! DAAAAAA!");
            RuleFor(x => x.Name).Length(10, 20).WithMessage("No seas pendeje, ese nombre no vende porque es muy corto o largo!!! DAAAAAAAAAAA x2!");
            RuleFor(x => x.BrandId).NotNull().WithMessage(x => "La marca es obligatoria");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage(x => "Error con el número de marca");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => $"El valor debe ser mayor a cero");
        }
    }
}
