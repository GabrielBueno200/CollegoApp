using System.Net.Mime;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.DTOs;

namespace Application.Services.Interfaces
{
    public interface IAccountService {

        Task SignUpAsync(UserRegisterDTO user);

        Task<object> SignInAsync(UserLoginDTO user);

        Task SignOutAsync();    
    }
}