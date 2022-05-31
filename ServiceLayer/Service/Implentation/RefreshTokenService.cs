using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implentation
{
    public class RefreshTokenService : IRefreshTokenRepository
    {
        private readonly IRefreshService _refreshToken;
        public RefreshTokenService(IRefreshService refreshToken)
        {
            _refreshToken = refreshToken;
        }

        public Task<bool> Add(RefreshToken model)
        {
            return _refreshToken.Add(model);
        }

        public Task<bool> Delete(RefreshToken model)
        {
            return _refreshToken.Delete(model);
        }

        public RefreshToken Get(int userId)
        {
            return _refreshToken.Get(userId);
        }

        public bool Update(RefreshToken model)
        {
            return _refreshToken.Update(model);  
        }
    }
}
