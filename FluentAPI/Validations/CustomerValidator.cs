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
        }
    }
}