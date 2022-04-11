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

            //RegularAndCollectionValidation()
            //InheritValidation();
            //RuleSetValidation();

            await Task.CompletedTask;
            return Ok();
        }


        private void RuleSetValidation()
        {
           var validator =  new ClientValidator();
           var client =  new Client();
           //var result = validator.Validate(client);

           // Surname and Forename are grouped together in a “Names” RuleSet.
           //We can invoke only these rules by passing additional options to the Validate method:
           //var result = validator.Validate(client, options=> options.IncludeRuleSets("Names"));

            // can execute multiple rulesets by passing multiple ruleset names to IncludeRuleSets:
            // var result = validator.Validate(client, options => {
            //     options.IncludeRuleSets("Names", "MyRuleSet", "SomeOther");
            // });

            // can also include all the rules not part of a ruleset by using calling IncludeRulesNotInRuleSet, 
            // or by using the special name “default” (case insensitive):
            // var result = validator.Validate(client, options => {
            //     // Option 1: IncludeRulesNotInRuleSet is the equivalent of using the special ruleset name "default"
            //     //options.IncludeRuleSets("Names").IncludeRulesNotInRuleSet();

            //     // Option 2: This does the same thing
            //     options.IncludeRuleSets("Names", "default");
            //  });

            // can force all rules to be executed regardless of whether or not they’re in a ruleset by calling IncludeAllRuleSets 
            //(this is the equivalent of using IncludeRuleSets("*") )
            var result = validator.Validate(client, options => {
                options.IncludeAllRuleSets();
             });



           string allMessages = result.ToString("~");
           Console.WriteLine(allMessages);

        }
        private void InheritValidation()
        {
            ContactRequest contRequest = new ContactRequest();
            contRequest.Contact = new Organisation();
            contRequest.Contact.Name = "Siva";

            ContactRequestValidator validator = new ContactRequestValidator();
            ValidationResult result = validator.Validate(contRequest);
            string allMessages = result.ToString("~");
            Console.WriteLine(allMessages);
        }
        private void RegularAndCollectionValidation()
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
            // validator.Validate(customer, options => {
            //     options.ThrowOnFailures();

            //     options.IncludeRuleSets("MyRules");
            //     options.IncludeProperties(x=> x.Forename);
            // });
        }
    }
}