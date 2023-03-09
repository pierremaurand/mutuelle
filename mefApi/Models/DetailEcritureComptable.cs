using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class DetailEcritureComptable
    {
        public int Id { get; set; }
        public CompteComptable? CompteComptable { get; set; }
        [Required]
        public TypeOperation? TypeOperation { get; set; }
        [Required]
        public decimal? Montant { get; set; }
    }
}