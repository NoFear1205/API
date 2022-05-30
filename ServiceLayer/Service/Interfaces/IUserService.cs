using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IUserService
    {
        bool Add(User model);
        User FindById(string username);
        bool Update(User model);
        bool Delete(User model);
        bool SetRefreshToken(string username,string refreshToken);
        bool DeleteRefreshToken(string username);
        string? getRefreshToken(string username);
    }
}
