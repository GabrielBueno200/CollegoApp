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
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Entities
{
    public class AccountService : IAccountService {

        private readonly IAccountRepository _accountRepository;

        private readonly IUserService _userService;
        
        private readonly IMapper _mapper;

        private readonly IValidator<UserRegisterDTO> _registerDTOValidator;

        private readonly JWTSettings _JWTSettings;

        private readonly ResponseResult responseHandler;

        public AccountService(IAccountRepository accountRepository, 
                              IUserService userService,
                              IMapper mapper,
                              IValidator<UserRegisterDTO> registerDTOValidator,
                              IOptions<JWTSettings> JWTSettings,
                              ResponseResult responseHandler){
            _accountRepository = accountRepository;
            _userService = userService;
            _mapper = mapper;
            _registerDTOValidator = registerDTOValidator;
            _JWTSettings = JWTSettings.Value;
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

        public async Task SignInAsync(UserLoginDTO user){

            throw new NotImplementedException();

        }

        public async Task SignOutAsync(){

            throw new NotImplementedException();

        }


        public async Task<string> GenerateToken(string email){

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_JWTSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Issuer = _JWTSettings.Issuer,
                Audience = _JWTSettings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_JWTSettings.Expires_In),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature 
                )
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}