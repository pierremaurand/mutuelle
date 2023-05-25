using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceCredit : BaseEntity
    {
        [Required]
        public int CreditDebourseId { get; set; }
        public CreditDebourse? CreditDebourse { get; set; }
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal Pricipal { get; set; } = 0;
        [Required]
        public decimal Interet { get; set; } = 0;
    }
}