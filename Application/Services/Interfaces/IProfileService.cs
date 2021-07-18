using System;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IProfileService {

        Task<UserViewModel> GetCurrentUserAsync(string username);

        Task DeleteAsync(string username);
        
        Task<User> EditAsync(Guid id);
        
        IQueryable<User> List();

        Task SignOutAsync(string token);
         
    }
}