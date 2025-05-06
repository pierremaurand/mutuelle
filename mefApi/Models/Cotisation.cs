using mefapi.Enums;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Cotisation : BaseEntity
    {
        //[Required]
        //public int MembreId { get; set; } 
        //public Membre? Membre { get; set; }
        [Required]
        public Mois Mois { get; set; }
        [Required]
        public int Annee { get; set; } 
        [Required]
        public decimal Montant { get; set; } 
        public ICollection<Mouvement>? Mouvements { get; set; }
    }
}