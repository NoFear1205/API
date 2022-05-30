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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRole;
        public UserRoleService(IUserRoleRepository userRole)
        {
            _userRole = userRole;
        }
        public bool Add(User_Role model)
        {
            return _userRole.Add(model);
        }

        public bool Delete(User_Role model)
        {
            return _userRole.Delete(model);
        }

        public List<User_Role> GetByUserId(int id)
        {
            return _userRole.GetByUserId(id);
        }
    }
}
