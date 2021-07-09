using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Utils;
using AutoMapper;
using Domain.Models;
using Domain.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Entities
{
    public class AccountService : IAccountService {


        private readonly IAccountRepository _accountRepository;
        
        private readonly IMapper _mapper;

        private readonly IValidator<UserRegisterDTO> _registerDTOValidator;

        private readonly IUserValidator<User> _userValidator;

        private readonly ResponseResult responseHandler;

        public AccountService(IAccountRepository accountRepository, IMapper mapper,
                              IUserValidator<User> userValidator,
                              IValidator<UserRegisterDTO> registerDTOValidator,
                              ResponseResult responseHandler){
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userValidator = userValidator;
            _registerDTOValidator = registerDTOValidator;
            this.responseHandler = responseHandler;
        }

        public async Task CreateAsync(UserRegisterDTO userDto){

            #region DTO Validation
            
            var dtoValidationResult = await _registerDTOValidator.ValidateAsync(userDto);

            if (!dtoValidationResult.IsValid) {
                responseHandler.Errors = ResponseErrors.getResultErrors(dtoValidationResult);
                return;
            }
            
            #endregion

            
            #region User validation

            var user = _mapper.Map<User>(userDto);

            var isEmailAvailable = (await _accountRepository.FindByEmailAsync(user.Email)) == null;
            var isUsernameAvailable = (await _accountRepository.FindByUsernameAsync(user.UserName)) == null ;
            
            if (!isEmailAvailable){
                responseHandler.Errors = ResponseErrors.AddError(responseHandler.Errors, "Endereço de e-mail já cadastrado!", ErrorType.NOT_AVAILABLE);
                return;
            }
            
            if (!isUsernameAvailable){
                responseHandler.Errors = ResponseErrors.AddError(responseHandler.Errors, "Username já cadastrado!");
                return;
            }

            var userValidationResult = await _accountRepository.ValidateAsync(_userValidator, user);

            if (!userValidationResult.Succeeded){
                responseHandler.Errors = ResponseErrors.getIdentityResultErrors(userValidationResult);
                return;
            }

            #endregion

            
            #region User Registration
            
            await _accountRepository.CreateAsync(user, userDto.Password);

            #endregion
            
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> List()
        {
            throw new NotImplementedException();
        }
    }
}