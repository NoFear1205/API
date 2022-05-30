using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{

    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Role model)
        {
            _context.Role.Add(model);
            int row_Count = _context.SaveChanges();
            return row_Count > 0;
        }

        public bool Delete(Role model)
        {
            _context.Role.Remove(model);
            int row_Count = _context.SaveChanges();
            return (row_Count > 0);
        }

        public Role? Get(int id)
        {
            Role? result= _context.Role.Find(id);
           return result;
        }

        public List<Role> List()
        {
            return _context.Role.ToList();
        }

        public bool Update(Role model)
        {
            _context.Role.Update(model);
            int row_Count = _context.SaveChanges();
            return row_Count > 0;
        }
    }
}
