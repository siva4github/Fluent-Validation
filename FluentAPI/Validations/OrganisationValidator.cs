using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class OrganisationValidator : AbstractValidator<Organisation>
    {
        public OrganisationValidator()
        {
            RuleFor(o => o.Name).NotNull();
            RuleFor(o => o.Email).NotNull();
            RuleFor(o => o.Headquarters).SetValidator(new AddressValidator());
        }
    }
}