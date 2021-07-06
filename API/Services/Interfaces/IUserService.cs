using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace API.Services.Interfaces
{
    public interface IUserService {

        Task<User> Create(User user);

        void Delete(Guid id);
        
        Task<User> Edit(Guid id);

        IQueryable<User> List();
         
    }
}