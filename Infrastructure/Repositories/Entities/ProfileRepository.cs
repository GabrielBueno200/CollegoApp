using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Entities
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