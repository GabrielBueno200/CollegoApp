using System.Net.Mime;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Utils;
using Domain.Models;
using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IAccountService {

        Task SignUpAsync(UserRegisterDTO user);

        Task<object> SignInAsync(UserLoginDTO user);

        Task SignOutAsync();    
    }
}