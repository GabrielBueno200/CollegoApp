using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Entities
{
    public class ProfileRepository : IProfileRepository
    {
        public Task<IdentityResult> DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> EditAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}