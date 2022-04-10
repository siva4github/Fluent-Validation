using FluentAPI.Entities;
using FluentAPI.Validations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FluentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FluentValidationsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Validate()
        {

            Customer customer = new Customer();
            customer.Surname = "foo";
            CustomerValidator validator = new CustomerValidator();

            ValidationResult result = validator.Validate(customer);

            if(!result.IsValid)
            {
                foreach(var failure in result.Errors)
                {
                    Console.WriteLine($"Property : {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
                }

                // or can also use ToString method

                string allMessages = result.ToString("~");
                Console.WriteLine(allMessages);
            }

            // alternatively we can validate and throw 

            //validator.ValidateAndThrow(customer);
            // or
            //validator.Validate(customer, options => options.ThrowOnFailures());
            //or
            validator.Validate(customer, options => {
                options.ThrowOnFailures();

                options.IncludeRuleSets("MyRules");
                options.IncludeProperties(x=> x.Forename);
            });

            await Task.CompletedTask;
            return Ok();
        }
    }
}