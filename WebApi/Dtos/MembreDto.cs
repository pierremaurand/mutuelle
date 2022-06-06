using WebApi.Models;

namespace WebApi.Dtos
{
    public class MembreDto
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int? SexeId { get; set; }
        public string? Photo { get; set; }
        public int? AgenceId { get; set; }
        public AgenceDto? Agence { get; set; }
        public int? ServiceId { get; set; }
        public ServiceDto? Service { get; set; }
        public Boolean? EstActif { get; set; }
        public decimal? FraisAdhesion { get; set; }
        public DateTime? DateAdhesion { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public ICollection<CotisationDto>? Cotisations { get; set; }
        public ICollection<AvanceDto>? Avances { get; set; }
        public ICollection<CreditDto>? Credits { get; set; } 
    }
}