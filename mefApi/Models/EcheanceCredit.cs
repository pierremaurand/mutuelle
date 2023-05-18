using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceCredit : BaseEntity
    {
        [Required]
        public int CreditId { get; set; }
        public Credit? Credit { get; set; }
        [Required]
        public int MoisId { get; set; } = 0;
        public Mois? Mois { get; set; } 
        [Required]
        public int Annee { get; set; } = 0;
        [Required]
        public decimal MontantCapital { get; set; } = 0;
        [Required]
        public decimal MontantInteret { get; set; } = 0;
        [Required]
        public decimal MontantCommission { get; set; } = 0;
        public bool EstPaye { get; set; } = false;
    }
}