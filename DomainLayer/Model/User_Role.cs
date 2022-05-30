using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class User_Role
    {
        public int UserID { get; set; }
        public User Users { get; set; }

        public int RoleID { get; set; }
        public Role Roles { get; set; }
    }
}
