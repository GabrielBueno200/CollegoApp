using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IProfileRepository {

        Task<IdentityResult> DeleteAsync(User user);
        
        Task<IdentityResult> EditAsync(User user);
         
    }
}