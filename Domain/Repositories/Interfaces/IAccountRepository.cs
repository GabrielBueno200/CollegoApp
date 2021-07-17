using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories.Interfaces
{
    public interface IAccountRepository{

        Task SignUpAsync(User user, string password);

        Task<SignInResult> SignInAsync(User user, string password);

    }
}