using System.ComponentModel.DataAnnotations;
using mefapi.Enums;

namespace mefApi.Dtos
{
    public class UtilisateurDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Le nom d'utilisateur est obligatoire")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Le rôle est obligatoire")]
        public Role? Role { get; set; }
        public string? Photo { get; set; }
    }
}