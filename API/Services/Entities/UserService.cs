using System;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Domain;

namespace API.Services.Entities
{
    public class UserService : IUserService {


        private readonly IUserRepository _repository;


        public UserService(IUserRepository repository){
            _repository = repository;
        }

        public Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Edit(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> List()
        {
            throw new NotImplementedException();
        }
    }
}