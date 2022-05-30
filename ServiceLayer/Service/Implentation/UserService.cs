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
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        public UserService(IUserRepository user)
        {
            _user = user;
        }
        public bool Add(User model)
        {
            return _user.Add(model);
        }

        public bool Delete(User model)
        {
            return _user.Delete(model);
        }

        public User FindById(string username)
        {
             return _user.FindById(username);   
        }

        public bool Update(User model)
        {
            return _user.Update(model);
        }
    }
}
