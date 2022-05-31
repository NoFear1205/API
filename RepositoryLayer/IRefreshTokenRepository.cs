using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRefreshService
    {
        Task<bool> Add(RefreshToken model);
        bool Update(RefreshToken model);
        Task<bool> Delete(RefreshToken model);
        RefreshToken Get(int userId);
    }
}
