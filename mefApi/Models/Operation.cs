using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Operation
    {
        public int Id { get; set; }
        [Required]
        public int CompteComptableId { get; set; }
        [Required]
        public TypeOperation TypeOperation { get; set;}
        [Required]
        public decimal Taux { get; set; }
    }
}