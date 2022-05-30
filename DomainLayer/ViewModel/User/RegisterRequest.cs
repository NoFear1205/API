using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.User
{
    public class RegisterRequest
    {
        [Required(ErrorMessage ="Tên tài khoản không được để trống")]
        [MaxLength(30)]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        [MaxLength(30)]
        public string? Password { get; set; }
        [Required(ErrorMessage ="Nhập lại mật khẩu không được để trống")]
        [MaxLength(30)]
        public string? RePassword { get; set; }
        public List<int>? RoleID { get; set; }
    }
}
