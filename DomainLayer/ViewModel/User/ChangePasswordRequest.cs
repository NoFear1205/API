using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.User
{
    public class ChangePasswordRequest
    {
        [Required]
        public string password { get; set; } = string.Empty;
        [Required]
        public string newpassword { get; set; } = string.Empty;
        [Required] 
        public string repassword { get; set; } = string.Empty;
    }
}
