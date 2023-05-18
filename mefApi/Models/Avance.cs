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
        public decimal Montant { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
        public bool? Avis1 { get; set; } = false;
        public bool? Avis2 { get; set; } = false;
    }
}