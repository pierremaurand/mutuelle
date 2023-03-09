using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Membre : BaseEntity
    {
        [Required]
        public string? Nom { get; set; } 
        public int? PersonnelId { get; set; }
        public bool EstActif { get; set; }
        [Required]
        public int SexeId { get; set; }
        public Sexe? Sexe { get; set; }
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
        public ICollection<MvtCompte> MvtComptes { get; set; } = new List<MvtCompte>();
        public ICollection<Avance> Avances { get; set; } = new List<Avance>();
        public ICollection<Credit> Credits { get; set; } = new List<Credit>();
        public ICollection<Cotisation> Cotisations { get; set; } = new List<Cotisation>();
    }
}