using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class CompteComptable : BaseEntity
    {
        [Required]
        public string? Compte { get; set; }
        [Required]
        public string? Libelle { get; set; }
        public ICollection<DetailEcritureComptable> DetailEcritureComptables { get; set; } = new List<DetailEcritureComptable>();
    }
}