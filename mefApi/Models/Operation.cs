using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Operation : BaseEntity
    {
        [Required]
        public int CompteComptableId { get; set; }
        public CompteComptable? CompteComptable { get; set; }
        [Required]
        public TypeOperation TypeOperation { get; set;} = 0;
        [Required]
        public decimal Taux { get; set; } = 0;
    }
}