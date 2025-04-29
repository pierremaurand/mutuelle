using mefapi.Enums;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Utilisateur : BaseEntity
    {
        [Required]
        public string? NomUtilisateur { get; set; }
        [Required]
        public byte[]? MotDePasse { get; set; }
        [Required]
        public byte[]? ClesMotDePasse { get; set; }
        [Required]
        public TypeUtilisateur? Type { get; set; } 
        public string? Photo { get; set; }
    }
}