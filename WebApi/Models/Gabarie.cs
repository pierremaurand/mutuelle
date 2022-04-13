using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Gabarie : BaseEntity
    {
        [Required]
        public string Libelle { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public ICollection<MvtGabarie>? MvtGabaries { get; set; }
    }
}