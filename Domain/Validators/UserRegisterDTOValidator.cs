using Domain.DTOs;
using FluentValidation;

namespace Domain.Validators
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>{
        
        public UserRegisterDTOValidator(){

            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage(ErrorsContants.PASSWORD_CONFIRM);
            RuleFor(x => x.userName).NotNull().WithMessage(ErrorsContants.FORGOT_FIELD);
            RuleFor(x => x.FullName).NotNull().WithMessage(ErrorsContants.FORGOT_FIELD);
            RuleFor(x => x.TermsAccepted).NotNull().Must((x, value, ctx) => value).WithMessage(ErrorsContants.TERMS_NOT_ACCEPTED);
        }

        
    }
}