using _004_Example3.DTOs.Patients;
using FluentValidation;

namespace _004_Example3.Validators
{
    public class PatientsPostValidator : AbstractValidator<PatientsPostDTO>
    {

        public PatientsPostValidator() 
        {
        
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(2,50);

            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(2, 50);

            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address).Length(5, 50);

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address).Length(10);

        }

    }
}
