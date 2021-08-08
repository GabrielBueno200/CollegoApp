using Application.Core.DTOs;
using Application.Notifications.Constants;
using FluentValidation;

namespace Application.Core.DTOs.Validators
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>{
        
        public UserRegisterDTOValidator(){

            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage(ErrorsConstants.PASSWORD_CONFIRM);
            RuleFor(x => x.userName).NotNull().WithMessage(ErrorsConstants.FORGOT_FIELD);
            RuleFor(x => x.FullName).NotNull().WithMessage(ErrorsConstants.FORGOT_FIELD);
            RuleFor(x => x.TermsAccepted).NotNull().Must((x, value, ctx) => value).WithMessage(ErrorsConstants.TERMS_NOT_ACCEPTED);
        }
    }

    public class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>{

        public UserLoginDTOValidator(){

            RuleFor(x => x.Email).EmailAddress().Must((x, value, ctx) => x.UserName == null || (value == null && x.UserName != null)).WithMessage("Insira e-mail ou username (não ambos)!");
            RuleFor(x => x.Password).NotNull().WithMessage(ErrorsConstants.FORGOT_FIELD);
        }
    }
}