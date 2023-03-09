using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceAvance
    {
        public int Id { get; set; }
        [Required]
        public int AvanceId { get; set; }
        public Avance? Avance { get; set; }
        [Required]
        public int MoisId { get; set; }
        public Mois? Mois { get; set; }
        [Required]
        public int? Annee { get; set; }
        [Required]
        public decimal? Montant { get; set; }
        public bool? EstPaye { get; set; }
        public ICollection<MvtCompte> MvtComptes { get; set; } = new List<MvtCompte>();
    }
}