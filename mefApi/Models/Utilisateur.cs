using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Utilisateur : BaseEntity
    {
        [Required(ErrorMessage ="Le nom d'utilisateur est obligatoire")]
        public string? NomUtilisateur { get; set; }
        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        public byte[]? MotDePasse { get; set; }
        public byte[]? ClesMotDePasse { get; set; }
        public int? MembreId { get; set; }
        public Membre? Membre { get; set; }
        [Required(ErrorMessage ="Le type d'utilisateur est obligatoire")]
        public TypeUtilisateur? Type { get; set; }
    }
}