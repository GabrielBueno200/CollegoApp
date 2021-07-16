using System;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using Domain.Models;
using Domain.DTOs;

namespace API.Services.Interfaces
{
    public interface IAccountService {

        Task SignUpAsync(UserRegisterDTO user);

        Task<object> SignInAsync(UserLoginDTO user);

        Task SignOutAsync();    
    }
}