using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.User
{
    public class LoginResponseDTO
    {
        public string Username { get; set; }
        public List<string> RoleName { get; set; }
    }
}
