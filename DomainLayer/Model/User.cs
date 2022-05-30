using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] HashPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IList<User_Role> UserRole { get; set; }
    }
}
