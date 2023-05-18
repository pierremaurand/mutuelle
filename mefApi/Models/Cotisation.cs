using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Cotisation 
    {
        public int Id { get; set; }
        [Required]
        public int MembreId { get; set; } = 0;
        public Membre? Membre { get; set; }
        [Required]
        public int MoisId { get; set; }
        public Mois? Mois { get; set; }
        [Required]
        public int Annee { get; set; } = 0;
        [Required]
        public decimal Montant { get; set; } = 0;
        public bool EstValide { get; set; } = true;
    }
}