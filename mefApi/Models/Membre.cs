using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Membre : BaseEntity
    {
        public string? Nom { get; set; } 
        public int PersonnelId { get; set; }
        public bool EstActif { get; set; }
        public int SexeId { get; set; }
        public Sexe? Sexe { get; set; }
        public int LieuAffectationId { get; set; }
        public LieuAffectation? LieuAffectation { get; set; }
        public int PosteId { get; set; }
        public Poste? Poste { get; set; }
        public string? DateNaissance { get; set; } 
        public string? DateAdhesion { get; set; } 
        public string? LieuNaissance { get; set; }
        public string? Photo { get; set; } 
        public string? Contact { get; set; }
        public string? Email { get; set; }
    }
}