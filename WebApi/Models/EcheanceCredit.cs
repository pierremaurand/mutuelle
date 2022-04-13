using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("EcheanceCredits")]
    public class EcheanceCredit : BaseEntity
    {
        public DateTime DateEcheance { get; set; }
        public decimal Montant { get; set; }
        public bool EstPaye { get; set; }
        public int CreditId { get; set; }
        public Credit? Credit { get; set; }
    }
}