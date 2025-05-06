using mefapi.Enums;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Utilisateur : BaseEntity
    {
        public string? Login { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? PasswordKey { get; set; }
        public Role? Role { get; set; } 
        public string? Photo { get; set; }
    }
}