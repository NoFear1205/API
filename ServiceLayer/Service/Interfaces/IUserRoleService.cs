using DomainLayer.Model;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IUserRoleService
    {
        List<User_Role> GetByUserId(int id);
        bool Add(User_Role model);
        bool Delete(User_Role model);
    }
}
