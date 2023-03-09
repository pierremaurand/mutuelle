using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcritureComptable : BaseEntity
    {
        [Required]
        public string? Libelle { get; set; }
        [Required]
        public decimal? Montant { get; set; }
        [Required]
        public int? GabaritId { get; set; }
        public Gabarit? Gabarit { get; set; }
        public ICollection<DetailEcritureComptable> DetailEcritureComptables { get; set; } = new List<DetailEcritureComptable>();
    }
}