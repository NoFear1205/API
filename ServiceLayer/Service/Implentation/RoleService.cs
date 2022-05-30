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
    public class RoleService : IRoleService
    {   
        private readonly IRoleRepository _role;
        public RoleService(IRoleRepository role)
        {
            _role = role;
        }
        public bool Add(Role model)
        {
            return _role.Add(model);
        }

        public bool Delete(Role model)
        {
            return _role.Delete(model);
        }

        public Role Get(int id)
        {
            return _role.Get(id);
        }

        public List<Role> List()
        {
            return _role.List();
        }

        public bool Update(Role model)
        {
            return _role.Update(model);
        }
    }
}
