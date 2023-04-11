using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Credit 
    {
        public int Id { get; set; }
        [Required]
        public int? MembreId { get; set; }
        public Membre? Membre { get; set; }
        [Required]
        public decimal? MontantCapital { get; set; }
        [Required]
        public decimal? MontantCommission { get; set; }
        [Required]
        public decimal? MontantInteret { get; set; }
        public int? NombreEcheances { get; set; }
        [Required]
        public string? DateEnregistrement { get; set; }
        public string? DateDeblocage { get; set; }
        public string? DateSolde { get; set; }
        public ICollection<EcheanceCredit> EcheanceCredits { get; set; } = new List<EcheanceCredit>();
        public ICollection<MvtCompte> MvtComptes { get; set; } = new List<MvtCompte>();
    }
}