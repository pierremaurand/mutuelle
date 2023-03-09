using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class MvtCompte 
    {
        public int Id { get; set; }
        [Required]
        public string? DateMvt { get; set; }
        [Required]
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        [Required]
        public TypeOperation TypeOperation { get; set;}
        [Required]
        public int GabaritId { get; set; }
        public Gabarit? Gabarit { get; set; }
        [Required]
        public string? Libelle { get; set; }
        [Required]
        public decimal Montant { get; set; }
        public int? AvanceId { get; set; }
        public Avance? Avance { get; set; }
        public int? CotisationId { get; set; }
        public Cotisation? Cotisation { get; set; }
        public int? CreditId { get; set; }
        public Credit? Credit { get; set; }
        public int? EcheanceAvanceId { get; set; }
        public EcheanceAvance? EcheanceAvance { get; set; }
        public int? EcheanceCreditId { get; set; }
        public EcheanceCredit? EcheanceCredit { get; set; }
        public ICollection<EcritureComptable> EcritureComptable { get; set; } = new List<EcritureComptable>();
    }
}