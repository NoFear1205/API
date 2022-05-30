using DomainLayer.Model;
using DomainLayer.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IUserRepository
    {
        bool Add(User model);
        User FindById(string username);
        bool Update(User model);
        bool Delete(User model);
        bool SetRefreshToken(string username,string refreshToken);
        bool DeleteRefreshToken(string username);
    }
}
