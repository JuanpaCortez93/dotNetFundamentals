using _004_Example5_Complete.DTOs.Students;
using FluentValidation;

namespace _004_Example5_Complete.FormatValidators.Students
{
    public class StudentsPostValidator : AbstractValidator<StudentsPostDTO>
    {
        public StudentsPostValidator() 
        {
            RuleFor(student => student.FirstName).NotNull().NotEmpty().WithMessage("Field can not be null or empty");
            RuleFor(student => student.LastName).NotNull().NotEmpty().WithMessage("Field can not be null or empty");
            RuleFor(student => student.Address).NotNull().NotEmpty().WithMessage("Field can not be null or empty");
            RuleFor(student => student.Telephone).NotNull().NotEmpty().WithMessage("Field can not be null or empty");
            RuleFor(student => student.Telephone).Length(8,10).WithMessage("Field can only have between 8 and 10 digits");
        }
    }
}
