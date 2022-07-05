using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User: BaseEntity
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public byte[]? Password { get; set; }
        public byte[]? PasswordKey { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

    }
}