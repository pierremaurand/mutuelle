using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceAvance : BaseEntity
    {
        [Required]
        public int AvanceDebourseId { get; set; }
        public AvanceDebourse? AvanceDebourse { get; set; } 
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal MontantEcheance { get; set; } = 0;
    }
}