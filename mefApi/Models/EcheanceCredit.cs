using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class EcheanceCredit : BaseEntity
    {
        [Required]
        public int CreditId { get; set; }
        public Credit? Credit { get; set; }
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal Capital { get; set; } = 0;
        [Required]
        public decimal Interet { get; set; } = 0;
        public ICollection<Mouvement>? Mouvements { get; set; }
    }
}