using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace API.Services.Interfaces
{
    public interface IProfileService {

        Task DeleteAsync(string username);
        
        Task<User> EditAsync(Guid id);

        IQueryable<User> List();
         
    }
}