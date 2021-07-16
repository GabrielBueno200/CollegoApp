using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Utils;
using API.Settings;
using AutoMapper;
using Domain.Models;
using Domain.DTOs;
using FluentValidation;
using Domain.ViewModels;

namespace API.Services.Entities
{
    public class AccountService : IAccountService {

        private readonly IAccountRepository _accountRepository;

        private readonly IUserService _userService;

        private readonly IJwtService _jwtService;
        
        private readonly IMapper _mapper;

        private readonly IValidator<UserRegisterDTO> _registerDTOValidator;
        
        private readonly IValidator<UserLoginDTO> _loginDTOValidator;

        private readonly ResponseResult responseHandler;

        public AccountService(IAccountRepository accountRepository, 
                              IUserService userService,
                              IMapper mapper,
                              IValidator<UserRegisterDTO> registerDTOValidator,
                              IValidator<UserLoginDTO> loginDTOValidator,
                              IJwtService jwtService,
                              ResponseResult responseHandler){
            _accountRepository = accountRepository;
            _userService = userService;
            _jwtService = jwtService;
            _mapper = mapper;
            _loginDTOValidator = loginDTOValidator;
            _registerDTOValidator = registerDTOValidator;
            this.responseHandler = responseHandler;
        }

        public async Task SignUpAsync(UserRegisterDTO userDto){

            #region DTO Validation
            
            var dtoValidationResult = await _registerDTOValidator.ValidateAsync(userDto);

            if (!dtoValidationResult.IsValid) {
                responseHandler.Errors = ResponseErrors.getResultErrors(dtoValidationResult);
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
                responseHandler.Errors = ResponseErrors.getIdentityResultErrors(userValidationResult);
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
                responseHandler.Errors = ResponseErrors.getResultErrors(dtoValidationResult);
                return null;
            }
            
            #endregion

            #region Login validation

            
            var user = userDto.Email != null ? await _userService.FindByEmailAsync(userDto.Email)
                     : userDto.Username != null ? await _userService.FindByUsernameAsync(userDto.Username) : null;

            if (user == null){
                responseHandler.AddError($"Não encontrado usuário cadastrado com o username/e-mail informado!", ErrorType.ENTITY_NOT_FOUND);
                return null;
            }

            #endregion

            var token = _jwtService.GenerateToken(user);

            var result = await _accountRepository.SignInAsync(user, userDto.Password);

            if(!result.Succeeded){
                responseHandler.AddError("E-mail ou senha incorreto!", ErrorType.UNPROCESSABLE);
                return null;
            }

            return new {
                token = token,
                user = _mapper.Map<UserViewModel>(user)
            };


        }

        public async Task SignOutAsync(){

            throw new NotImplementedException();

        }

    }
}