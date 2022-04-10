using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            //RuleFor(customer => customer.Surname).NotNull();            

            RuleFor(customer => customer.Surname).NotNull().NotEqual("foo");      
            RuleFor(customer => customer.Address).SetValidator(new AddressValidator());

            //or Instead of using a child validator, you can define child rules inline,
            // explicitly add null check condition
            //RuleFor(customer => customer.Address.Postcode).NotNull().When(customer => customer.Address!=null);      
        }
    }
}