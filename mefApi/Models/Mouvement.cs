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
    }
}