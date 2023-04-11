using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le nom d'utilisateur est obligatoire")]
        public string NomUtilisateur { get; set; } = string.Empty;
        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public int? MembreId { get; set; }
        [Required(ErrorMessage ="Le type d'utilisateur est obligatoire")]
        public TypeUtilisateur Type { get; set; }
    }
}