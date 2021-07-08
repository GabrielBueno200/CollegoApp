using System;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using Domain;
using Domain.DTOs;

namespace API.Services.Interfaces
{
    public interface IAccountService {

        Task<ResponseResult> Create(UserRegisterDTO user);

        void Delete(Guid id);
        
        Task<User> Edit(Guid id);

        IQueryable<User> List();
         
    }
}