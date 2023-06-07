using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Mouvement : BaseEntity 
    {
        [Required]
        public string DateMvt { get; set; } = string.Empty;
        [Required]
        public TypeOperation TypeOperation { get; set;} = 0;
        [Required]
        public int GabaritId { get; set; } 
        public Gabarit? Gabarit { get; set; } 
        [Required]
        public string Libelle { get; set; } = string.Empty;
        [Required]
        public decimal Montant { get; set; } = 0;
        public Membre? Membre { get; set; } 
        public Cotisation? Cotisation { get; set; }
        public AvanceDebourse? AvanceDebourse { get; set; }
        public CreditDebourse? CreditDebourse { get; set; }
        public EcheanceAvance? EcheanceAvance { get; set; }
        public EcheanceCredit? EcheanceCredit { get; set; }
    }
}