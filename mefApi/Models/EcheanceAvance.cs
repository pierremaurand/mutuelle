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
        public int MoisId { get; set; }
        public Mois? Mois { get; set; }
        [Required]
        public int Annee { get; set; } = 0;
        [Required]
        public decimal Montant { get; set; } = 0;
        public bool EstPaye { get; set; } = false;
    }
}