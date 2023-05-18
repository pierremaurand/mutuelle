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
        public decimal MontantCapital { get; set; } = 0;
        [Required]
        public decimal MontantCommission { get; set; } = 0;
        [Required]
        public decimal MontantInteret { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
    }
}