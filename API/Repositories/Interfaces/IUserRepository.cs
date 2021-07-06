using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository{

        Task<IdentityResult> Create(User user);

        Task<IdentityResult> Delete(User user);
        
        Task<IdentityResult> Edit(User user);

        IQueryable<User> List();

         
    }
}