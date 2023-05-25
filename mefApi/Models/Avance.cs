using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Avance : BaseEntity
    {
        [Required]
        public int MembreId { get; set; } = 0;
        public Membre? Membre { get; set; }
        [Required]
        public decimal MontantSollicite { get; set; } = 0;
        [Required]
        public int NombreEcheancesSollicite { get; set; } = 0;
        [Required]
        public string DateDemande { get; set; } = string.Empty;
    }
}