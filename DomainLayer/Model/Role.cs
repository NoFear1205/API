using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required(ErrorMessage ="Tên role ko được để trống ")]
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IList<User_Role>? UserRole { get; set; }
    }
}
