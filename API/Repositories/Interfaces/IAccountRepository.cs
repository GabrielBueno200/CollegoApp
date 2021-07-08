using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IAccountRepository{

        Task<IdentityResult> Create(User user, string password);

        Task<IdentityResult> Delete(User user);
        
        Task<IdentityResult> Edit(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByUsername(string username);

        Task<IdentityResult> ValidateAsync(IUserValidator<User> validator, User user);

        IQueryable<User> List();

         
    }
}