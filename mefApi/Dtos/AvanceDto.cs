using WebApi.Models;

namespace WebApi.Dtos
{
    public class AvanceDto
    {
        public int? Id { get; set; }
        public string? DateDeblocage { get; set; } = string.Empty;
        public string? DateDebut { get; set; } = string.Empty;
        public string? DateFin { get; set; } = string.Empty;
        public decimal? Montant { get; set; }
        public Boolean? EstValide { get; set; }
        public int? MembreId { get; set; }
        public ICollection<EcheanceAvanceDto> EcheanceAvances { get; set; } = new List<EcheanceAvanceDto>();
    }
}