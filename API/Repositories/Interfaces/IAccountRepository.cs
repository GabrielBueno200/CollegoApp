using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IAccountRepository{

        Task<IdentityResult> CreateAsync(User user, string password);

        Task<IdentityResult> DeleteAsync(User user);
        
        Task<IdentityResult> EditAsync(User user);

        Task<IdentityResult> PutInStudentRoleAsync(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByUsernameAsync(string username);

        Task<IdentityResult> ValidateAsync(IUserValidator<User> validator, User user);

        IQueryable<User> List();

         
    }
}