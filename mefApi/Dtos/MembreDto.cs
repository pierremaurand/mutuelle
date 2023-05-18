using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class MembreDto
    {
        public int Id;
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        public string Nom { get; set; } = string.Empty;
        public int PersonnelId { get; set; } = 0;
        [Required(ErrorMessage = "Le Sexe est obligatoire")]
        public int SexeId { get; set; } = 0;
        [Required(ErrorMessage = "Le Poste est obligatoire")]
        public int PosteId { get; set; } = 0;
        [Required(ErrorMessage = "Le Lieu d'affectation est obligatoire")]
        public int LieuAffectationId { get; set; } = 0;
        [Required(ErrorMessage = "La Date de naissance est obligatoire")]
        public string DateNaissance { get; set; } = string.Empty;
        [Required(ErrorMessage = "La Date d'adhésion est obligatoire")]
        public string DateAdhesion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le Lieu de naissance est obligatoire")]
        public string LieuNaissance { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le Contact est obligatoire")]
        public string Contact { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EstActif { get; set; } = false;
        public string Photo { get; set; } = string.Empty;
    }
}