using AutoMapper;
using Domain.Models;
using FluentValidation;
using Application.Core.DTOs;
using Application.ViewModels;
using System.Threading.Tasks;
using Application.Core.Notifications;
using Domain.Repositories.Interfaces;
using Application.Services.Interfaces;

namespace Application.Services.Entities
{
    public class AccountService : IAccountService {

        private readonly IAccountRepository _accountRepository;

        private readonly IUserService _userService;

        private readonly ITokenGeneratorService _tokenGeneratorService;

        private readonly IMapper _mapper;

        private readonly IValidator<UserRegisterDTO> _registerDTOValidator;
        
        private readonly IValidator<UserLoginDTO> _loginDTOValidator;

        private readonly NotificationsContext _notificationsContext;

        public AccountService(IAccountRepository accountRepository, 
                              IUserService userService,
                              IMapper mapper,
                              IValidator<UserRegisterDTO> registerDTOValidator,
                              IValidator<UserLoginDTO> loginDTOValidator,
                              ITokenGeneratorService tokenGeneratorService,
                              NotificationsContext notificationsContext){
            _accountRepository = accountRepository;
            _userService = userService;
            _tokenGeneratorService = tokenGeneratorService;
            _mapper = mapper;
            _loginDTOValidator = loginDTOValidator;
            _registerDTOValidator = registerDTOValidator;
            _notificationsContext = notificationsContext;
        }

        public async Task SignUpAsync(UserRegisterDTO userDto){

            #region DTO Validation
            
            var dtoValidationResult = await _registerDTOValidator.ValidateAsync(userDto);

            if (!dtoValidationResult.IsValid) {
                _notificationsContext.Notifications = ResponseNotifications.getResultErrors(dtoValidationResult);
                return;
            }
            
            #endregion


            #region User validation

            var user = _mapper.Map<User>(userDto);

            var isEmailAvailable = await _userService.IsEmailAvailable(user.Email);
            if (!isEmailAvailable) 
                return;

            var isUsernameAvailable = await _userService.IsUsernameAvailable(user.UserName);
            if (!isUsernameAvailable)
                return;
        
            var userValidationResult = await _userService.ValidateAsync(user);

            if (!userValidationResult.Succeeded){
                _notificationsContext.Notifications = 
                    ResponseNotifications.getIdentityResultErrors(userValidationResult);
                return;
            }

            #endregion


            #region User Registration
            
            await _accountRepository.SignUpAsync(user, userDto.Password);
            await _userService.AddToRoleAsync(user, "STUDENT");

            #endregion
            
        }

        public async Task<object> SignInAsync(UserLoginDTO userDto){

            #region DTO Validation
            
            var dtoValidationResult = await _loginDTOValidator.ValidateAsync(userDto);

            if (!dtoValidationResult.IsValid) {
                _notificationsContext.Notifications = ResponseNotifications.getResultErrors(dtoValidationResult);
                return null;
            }
            
            #endregion

            #region Login validation

            
            /*LÓGICA PARA LOGIN COM USERNAME OU E-MAIL (REIMPLEMENTAR DEPOIS) 
            var user = userDto.Email != null ? await _userService.FindByEmailAsync(userDto.Email)
                     : userDto.UserName != null ? await _userService.FindByUsernameAsync(userDto.UserName) : null;

            if (user == null){
                _notificationsContext.AddNotification($"Não encontrado usuário cadastrado com o username/e-mail informado!", NotificationType.ENTITY_NOT_FOUND);
                return null;
            }*/

            var user = await _userService.FindByUsernameAsync(userDto.UserName);

            if (user == null){
                _notificationsContext.AddNotification($"Não encontrado usuário cadastrado com o nome de usuário {userDto.UserName}!", NotificationType.ENTITY_NOT_FOUND);
                return null;
            }

            #endregion

            var result = await _accountRepository.SignInAsync(user, userDto.Password);

            if(!result.Succeeded){
                _notificationsContext.AddNotification("Nome de usuário ou senha incorreto!", NotificationType.UNPROCESSABLE);
                return null;
            }

            var tokens = await _tokenGeneratorService.GenerateTokenAsync(user);

            return new {
                tokens = tokens,
                user = _mapper.Map<UserViewModel>(user)
            };

        }

    }
}