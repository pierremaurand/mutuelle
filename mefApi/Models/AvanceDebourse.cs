using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    [Table("AvancesDebourses")]
    public class AvanceDebourse : BaseEntity
    {
        [Required]
        public int AvanceId { get; set; } = 0;
        public Avance? Avance { get; set; }
        [Required]
        public decimal MontantApprouve { get; set; } = 0;
        [Required]
        public int NombreEcheancesApprouve { get; set; } = 0;
        [Required]
        public string DateDecaissement { get; set; } = string.Empty;
        public int MouvementId { get; set; }
        public Mouvement? Mouvement { get; set; }
        
    }
}