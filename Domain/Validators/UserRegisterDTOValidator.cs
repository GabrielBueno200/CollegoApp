using Domain.DTOs;
using FluentValidation;

namespace Domain.Validators
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>{
        
        public UserRegisterDTOValidator(){

            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword);
            RuleFor(x => x.userName).NotNull();
            RuleFor(x => x.FullName).NotNull();
            RuleFor(x => x.TermsAccepted).NotNull().Must((x, value, ctx) => value);
        }

        
    }
}