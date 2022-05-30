using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } =  string.Empty ;
    }
}
