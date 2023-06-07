using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Credit : BaseEntity 
    {
        [Required]
        public int MembreId { get; set; } = 0;
        public Membre? Membre { get; set; }
        [Required]
        public decimal MontantSollicite { get; set; } = 0;
        [Required]
        public int DureeSollicite { get; set; } = 0;
        [Required]
        public string DateDemande { get; set; } = string.Empty;
        public CreditDebourse? CreditDebourse { get; set; }
        public ICollection<EcheanceCredit>? Echeancier { get; set; }
    }
}