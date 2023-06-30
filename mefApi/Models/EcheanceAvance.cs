using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceAvance : BaseEntity
    {
        [Required]
        public int AvanceId { get; set; }
        public Avance? Avance { get; set; } 
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal MontantEcheance { get; set; } = 0;
        public ICollection<Mouvement>? Mouvements { get; set; }
    }
}