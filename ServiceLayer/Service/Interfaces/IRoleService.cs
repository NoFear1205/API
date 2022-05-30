using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IRoleService
    {
        bool Add(Role model);
        bool Update(Role model);
        bool Delete(Role model);
        Role Get(int id);
        List<Role> List();
    }
}
