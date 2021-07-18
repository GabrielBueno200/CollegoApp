using System.Threading.Tasks;
using Application.Core.DTOs;
using Application.Core.DTOs.Entities;

namespace Application.Services.Interfaces
{
    public interface IAccountService {

        Task SignUpAsync(UserRegisterDTO user);

        Task<object> SignInAsync(UserLoginDTO user);

    }
}