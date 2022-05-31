using DomainLayer.Model;
using DomainLayer.ViewModel.User;
using RepositoryLayer.DbContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(User model)
        {
            _context.Users.Add(model);
            int row_Count = _context.SaveChanges();
            return row_Count > 0;
        }


        public bool Delete(User model)
        {
            _context.Users.Remove(model);
            int row_Count = _context.SaveChanges();
            return (row_Count > 0);
        }

        public User FindById(string username)
        {
            User? result = _context.Users.Where(c=>c.Username.Equals(username)).FirstOrDefault();
            return result;
        }

        public bool Update(User model)
        {
            _context.Users.Update(model);
            int row_Count = (_context.SaveChanges());
            return row_Count > 0;
        }
    }
}
