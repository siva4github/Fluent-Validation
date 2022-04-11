using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleSet("Names", ()=>{
                RuleFor(c=> c.Surname).NotNull();
                RuleFor(c=> c.Forename).NotNull();
            });

            RuleFor(c => c.Id).NotEqual(0);
        }
    }
}