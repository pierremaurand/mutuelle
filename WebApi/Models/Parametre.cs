using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Parametre : BaseEntity
    {
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Valeur { get; set; }
    }
}