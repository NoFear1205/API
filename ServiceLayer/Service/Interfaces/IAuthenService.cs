using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IAuthenService
    {
        string CreateToken(User user, List<string> roles);
        RefreshToken GenerateRefreshToken(int userId);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        RefreshToken GetRefreshToken(int userId);
        bool UpdateRefreshToken(RefreshToken model);
        Task<bool> AddRefreshToken(RefreshToken model);
    }
}
