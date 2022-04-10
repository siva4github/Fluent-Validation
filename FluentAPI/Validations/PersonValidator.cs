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
        }
    }
}