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

            var isEmailAvailable = await IsEmailAvailable(user.Email);
            if (!isEmailAvailable) 
                return;

            var isUsernameAvailable = await IsUsernameAvailable(user.UserName);
            if (!isUsernameAvailable)
                return;
        
            var userValidationResult = await _accountRepository.ValidateAsync(_userValidator, user);

            if (!userValidationResult.Succeeded){
                responseHandler.Errors = ResponseErrors.getIdentityResultErrors(userValidationResult);
                return;
            }

            #endregion


            #region User Registration
            
            await _accountRepository.CreateAsync(user, userDto.Password);
            await _accountRepository.PutInStudentRoleAsync(user);

            #endregion
            
        }

        public async Task<bool> IsEmailAvailable(string email){
            var isEmailAvailable = (await _accountRepository.FindByEmailAsync(email)) == null;
            
            if (!isEmailAvailable)
                responseHandler.AddError("Endereço de e-mail já cadastrado!", ErrorType.NOT_AVAILABLE);
                        
            return isEmailAvailable;
        }

        public async Task<bool> IsUsernameAvailable(string username){
            var isUsernameAvailable = (await _accountRepository.FindByUsernameAsync(username)) == null ;
            
            if (!isUsernameAvailable)
                responseHandler.AddError("Username já cadastrado!", ErrorType.NOT_AVAILABLE);

            return isUsernameAvailable;
        }

        public async Task DeleteAsync(string username){
           
           var user = await _accountRepository.FindByUsernameAsync(username);

           if(user == null){
                responseHandler.AddError($"Não encontrado usuário com o username {username}", ErrorType.ENTITY_NOT_FOUND);
                return;
            }

            await _accountRepository.DeleteAsync(user);
        }

        public Task<User> EditAsync(Guid id){
            throw new NotImplementedException();
        }

        public IQueryable<User> List(){
            throw new NotImplementedException();
        }
    }
}