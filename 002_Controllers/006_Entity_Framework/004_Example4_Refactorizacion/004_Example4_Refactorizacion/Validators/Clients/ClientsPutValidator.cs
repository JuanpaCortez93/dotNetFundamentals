using _004_Example4_Refactorizacion.DTOs.Clients;
using FluentValidation;

namespace _004_Example4_Refactorizacion.Validators.Clients
{
    public class ClientsPutValidator : AbstractValidator<ClientsPutDTO>
    {
        public ClientsPutValidator() 
        {
            RuleFor(client => client.FirstName).NotEmpty().WithMessage("Firstname can not be empty");
            RuleFor(client => client.LastName).NotNull().WithMessage("Firstname can not be null");
            RuleFor(client => client.LastName).Length(3, 50).WithMessage("Firstname need to have between 3 and 50 characters");
        }
    }
}
