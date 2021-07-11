using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IAccountRepository{

        Task SignUpAsync(User user, string password);

    }
}