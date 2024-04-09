using _004_Example5_Complete.DTOs.Teachers;
using FluentValidation;

namespace _004_Example5_Complete.FormatValidators.Teachers
{
    public class TeachersPostValidator : AbstractValidator<TeachersPostDTO>
    {

        public TeachersPostValidator() 
        {
        
            RuleFor(teacher => teacher.FirstName).NotEmpty().NotNull().WithMessage("Value can't be null or empty");
            RuleFor(teacher => teacher.LastName).NotEmpty().NotNull().WithMessage("Value can't be null or empty");
            RuleFor(teacher => teacher.Email).NotEmpty().NotNull().WithMessage("Value can't be null or empty");
            RuleFor(teacher => teacher.Password).NotEmpty().NotNull().WithMessage("Value can't be null or empty");

        }

    }
}
