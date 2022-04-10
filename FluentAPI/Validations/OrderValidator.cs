using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Total).GreaterThan(0);            
            
        }
    }
}