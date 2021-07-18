using System.Threading.Tasks;
using Domain.Models.Security;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories.Interfaces;

namespace Infrastructure.Repositories.Entities
{
    public class RefreshTokenRepository : IRefreshTokenRepository {

        private readonly DataContext _context;

        public RefreshTokenRepository(DataContext context){
            _context = context;
        }

        public async Task CreateAsync(RefreshToken token){
           _context.Add(token);
           await _context.SaveChangesAsync();
        }
        

        public async Task DeleteAsync(string token) {

            var requestedToken = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == token);
            
            _context.RefreshToken.Remove(requestedToken);
            
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> FindByTokenAsync(string refreshToken) => 
            await _context.RefreshToken.AsQueryable().FirstOrDefaultAsync(x => x.Token == refreshToken);

    }
}