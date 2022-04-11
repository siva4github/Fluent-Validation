using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            //The rule will run a NotNull check against each item in the AddressLines collection.
            RuleForEach(person => person.AddressLines).NotNull();

            RuleFor(p => p.Name).NotNull();
            RuleFor(p => p.Email).NotNull();
            RuleFor(p => p.DateOfBirth).GreaterThan(DateTime.MinValue);
        }
    }
}