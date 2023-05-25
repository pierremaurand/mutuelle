using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class CreditDebourse : BaseEntity
    {
        [Required]
        public int CreditId { get; set; } = 0;
        public Credit? Credit { get; set; }
        [Required]
        public decimal MontantAccorde { get; set; } = 0;
        [Required]
        public decimal MontantCommission { get; set; } = 0;
        [Required]
        public decimal MontantInteret { get; set; } = 0;
        [Required]
        public int DureeAccordee { get; set; } = 0;
        [Required]
        public string DateDecaissement { get; set; } = string.Empty;
    }
}