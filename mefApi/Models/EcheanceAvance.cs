using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("EcheanceAvances")]
    public class EcheanceAvance : BaseEntity
    {
        public string DateEcheance { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public bool EstPaye { get; set; }
        public int AvanceId { get; set; }
        public Avance Avance { get; set; } = new Avance{};
    }
}