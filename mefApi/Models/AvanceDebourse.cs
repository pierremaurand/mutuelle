using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class AvanceDebourse : BaseEntity
    {
        [Required]
        public int AvanceId { get; set; } = 0;
        public Avance? Avance { get; set; }
        [Required]
        public decimal MontantApprouve { get; set; } = 0;
        public int NombreEcheancesApprouve { get; set; } = 0;
        public string DateDecaissement { get; set; } = string.Empty;
    }
}