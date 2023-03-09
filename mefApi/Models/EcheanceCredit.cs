using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceCredit
    {
        public int Id { get; set; }
        [Required]
        public int CreditId { get; set; }
        public Credit? Credit { get; set; }
        [Required]
        public int MoisId { get; set; }
        public Mois? Mois { get; set; }
        [Required]
        public int? Annee { get; set; }
        [Required]
        public decimal? MontantCapital { get; set; }
        [Required]
        public decimal? MontantInteret { get; set; }
        public bool? EstPaye { get; set; }
        public ICollection<MvtCompte> MvtComptes { get; set; } = new List<MvtCompte>();
    }
}