using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class ContactRequestValidator : AbstractValidator<ContactRequest>
    {
        public ContactRequestValidator()
        {
            RuleFor(c => c.Contact).SetInheritanceValidator(v => {
                v.Add<Organisation>(new OrganisationValidator());
                v.Add<Person>(new PersonValidator());
            });
        }
    }
}