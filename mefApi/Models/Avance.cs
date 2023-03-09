using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Avance 
    {
        public int Id { get; set; }
        [Required]
        public int? MembreId { get; set; }
        public Membre? Membre { get; set; }
        [Required]
        public decimal? Montant { get; set; }
        public int? NombreEcheances { get; set; }
        [Required]
        public string? DateEnregistrement { get; set; }
        public string? DateDeblocage { get; set; }
        public string? DateSolde { get; set; }
        public ICollection<EcheanceAvance> EcheanceAvances { get; set; } = new List<EcheanceAvance>();
        public ICollection<MvtCompte> MvtComptes { get; set; } = new List<MvtCompte>();
    }
}