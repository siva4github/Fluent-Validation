using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Postcode).NotNull();
        }
    }
}