using Domain.DTOs;
using FluentValidation;

namespace Domain.Validators
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>{
        
        public UserRegisterDTOValidator(){

            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage(ErrorsContants.FORGOT_FIELD("{PropertyName}"));
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage(ErrorsContants.PASSWORD_CONFIRM);
            RuleFor(x => x.userName).NotNull().WithMessage(ErrorsContants.FORGOT_FIELD("{PropertyName}"));
            RuleFor(x => x.FullName).NotNull().WithMessage(ErrorsContants.FORGOT_FIELD("{PropertyName}"));
        }

        
    }
}