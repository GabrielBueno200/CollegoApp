using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IProfileService {

        Task DeleteAsync(string username);
        
        Task<User> EditAsync(Guid id);
        
        IQueryable<User> List();

        Task SignOutAsync(string token);
         
    }
}