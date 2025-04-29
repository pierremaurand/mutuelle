using mefapi.Enums;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Membre : BaseEntity
    {
        [Required]
        public string? Nom { get; set; }
        public bool EstActif { get; set; }
        [Required]
        public Sexe Sexe { get; set; } 
        [Required]
        public int LieuAffectationId { get; set; } 
        public LieuAffectation? LieuAffectation { get; set; } 
        [Required]
        public int PosteId { get; set; } 
        public Poste? Poste { get; set; }
        public string? DateNaissance { get; set; } 
        [Required]
        public string? DateAdhesion { get; set; }
        public string? LieuNaissance { get; set; } 
        public string? Photo { get; set; } 
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public ICollection<Mouvement>? Mouvements { get; set; }
        public ICollection<Cotisation>? Cotisations { get; set; }
        public ICollection<Avance>? Avances { get; set; }
        public ICollection<Credit>? Credits { get; set; }
    }
}