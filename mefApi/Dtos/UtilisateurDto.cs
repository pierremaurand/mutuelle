using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class UtilisateurDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage ="Le nom d'utilisateur est obligatoire")]
        public string NomUtilisateur { get; set; } = string.Empty;
        [Required(ErrorMessage ="L'Id du membre est obligatoire")]
        public int MembreId { get; set; }
        public TypeUtilisateur Type { get; set; } = TypeUtilisateur.Utilisateur;
    }
}