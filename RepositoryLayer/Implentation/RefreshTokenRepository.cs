using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class RefreshTokenRepository : IRefreshService
    {
        private readonly ApplicationDbContext _context;
        public RefreshTokenRepository(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<bool> Add(RefreshToken model)
        {
            _context.RefreshTokens.Add(model);
            int row_Count = await _context.SaveChangesAsync();
            return row_Count > 0;
        }

        public async Task<bool> Delete(RefreshToken model)
        {
            _context.RefreshTokens.Remove(model);
            int row_Count = await _context.SaveChangesAsync();
            return row_Count > 0;
        }

        public RefreshToken? Get(int userId)
        {
            return _context.RefreshTokens.Where(c=>c.userID == userId).FirstOrDefault();
        }

        public  bool Update(RefreshToken model)
        {
            _context.RefreshTokens.Update(model);
            int row_Count =  _context.SaveChanges();
            return row_Count > 0;
        }
    }
}
