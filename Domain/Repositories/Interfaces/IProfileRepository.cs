using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories.Interfaces
{
    public interface IProfileRepository {

        Task<IdentityResult> DeleteAsync(User user);
        
        Task<IdentityResult> EditAsync(User user);
         
    }
}