using System.Net.Mime;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Models;

namespace Application.Services.Entities
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