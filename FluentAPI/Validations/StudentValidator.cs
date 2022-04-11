using FluentAPI.Entities;
using FluentValidation;

namespace FluentAPI.Validations
{
    // we can include rules from other validators provided they validate the same type. 
    // This allows you to split rules across multiple classes and compose them together 
    // (in a similar way to how other languages support traits). For example, 
    // imagine you have 2 validators that validate different aspects of a Person:
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            Include(new StudentAgeValidator());
            Include(new StudentNameValidator());
        }
    }

    public class StudentAgeValidator : AbstractValidator<Student>
    {
        public StudentAgeValidator()
        {
            RuleFor(s => s.DateOfBirth).Must(BeOver18);
        }

        protected bool BeOver18(DateTime date)
        {
            // some logic

            return true;
        }
    }

    public class StudentNameValidator : AbstractValidator<Student>
    {
        public StudentNameValidator()
        {
            RuleFor(s => s.SurName).NotNull();
            RuleFor(s => s.ForeName).NotNull();
        }
    }

}