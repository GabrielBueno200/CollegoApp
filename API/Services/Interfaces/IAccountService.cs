using System;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using Domain.Models;
using Domain.DTOs;

namespace API.Services.Interfaces
{
    public interface IAccountService {

        Task CreateAsync(UserRegisterDTO user);

        Task DeleteAsync(Guid id);
        
        Task<User> EditAsync(Guid id);

        IQueryable<User> List();
         
    }
}