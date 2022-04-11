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

            RuleForEach(c => c.Orders).SetValidator(new OrderValidator());
            // or
            // RuleForEach(c => c.Orders).ChildRules(o => {
            //     o.RuleFor(x=> x.Total).GreaterThan(0);
            // });


            // alternative to using RuleForEach is to call ForEach as part of a regular RuleFor.

            // This rule acts on the whole collection (using RuleFor)
            RuleFor(c => c.Orders).Must(c => c.Count <= 10).WithMessage("No More than 10 orders are allowed");
            // This rule acts on each individual element (using RuleForEach)
            RuleForEach(c => c.Orders).Must(c => c.Total > 0).WithMessage("Order must have a total of more than 0");

            // Above two rules can be re-written as
            RuleFor(c => c.Orders).Must(c => c.Count <=10).WithMessage("No More than 10 orders are allowed")
                .ForEach(c => {
                    c.Must(c => c.Total > 0).WithMessage("Order must have a total of more than 0");
                });

        }
    }
}