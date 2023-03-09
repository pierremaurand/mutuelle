using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Gabarit : BaseEntity
    {
        [Required]
        public string? Libelle { get; set; }
        [Required]
        public TypeMouvement? TypeMouvement { get; set; }
        public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    }
}