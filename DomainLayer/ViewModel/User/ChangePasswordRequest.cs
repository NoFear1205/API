using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.User
{
    public class ChangePasswordRequest
    {
        public string password { get; set; }
        public string newpassword { get; set; }
        public string repassword { get; set; }
    }
}
