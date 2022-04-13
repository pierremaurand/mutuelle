using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("MvtCotisations")]
    public class MvtCotisation : BaseEntity
    {
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public bool EstDebit { get; set; }
        public decimal Montant { get; set; }
        public int CotisationId { get; set; }
        public Cotisation? Cotisation { get; set; }
    }
}