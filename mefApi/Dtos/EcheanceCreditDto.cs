using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class EcheanceCreditDto
    {
        public int Id { get; set; } = 0;
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal Capital { get; set; } = 0;
        [Required]
        public decimal Interet { get; set; } = 0;
        public int? CreditId { get; set; }
        public decimal? MontantPaye { get; set; }
    }
}