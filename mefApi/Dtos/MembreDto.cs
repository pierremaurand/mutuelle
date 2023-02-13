using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class MembreDto
    {
        public int? Id { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Required]
        public int? PersonnelId { get; set; }
        public bool? EstActif { get; set; }
        [Required]
        public SexeDto? Sexe { get; set; }
        [Required]
        public PosteDto? Poste { get; set; }
        public string? Photo { get; set; }
        [Required]
        public string? DateNaissance { get; set; }
        [Required]
        public string? LieuNaissance { get; set; }
        [Required]
        public string? Contact { get; set; }
        public string? Email { get; set; }
    }
}