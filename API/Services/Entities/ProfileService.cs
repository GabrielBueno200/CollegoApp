using System;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Domain.Models;

namespace API.Services.Entities
{
    public class ProfileService : IProfileService
    {
        public Task DeleteAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> List()
        {
            throw new NotImplementedException();
        }
    }
}