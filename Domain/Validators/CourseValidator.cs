using Domain.Models;
using FluentValidation;

namespace Domain.Validators
{
    public class CourseValidator : AbstractValidator<Course>{
        
        public CourseValidator(){

            RuleFor(x => x.Name).NotNull();

        }

        
    }
}