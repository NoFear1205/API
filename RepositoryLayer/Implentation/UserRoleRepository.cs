using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<User_Role> GetByUserId(int id)
        {
            var result = _context.User_Role.Include(c => c.Roles).Where(c => c.UserID == id).ToList();
            return result;
        }
        public bool Add(User_Role model)
        {
            _context.User_Role.Add(model);
            int row_Count = _context.SaveChanges();
            return row_Count > 0;
        }
        public bool Delete(User_Role model)
        {
            _context.User_Role.Remove(model);
            int row_Count = _context.SaveChanges();
            return row_Count > 0;
        }
    }
}
