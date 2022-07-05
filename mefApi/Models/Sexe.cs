using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Sexe: BaseEntity
    {
        [Required]
        public string Nom { get; set; } = string.Empty;
    }
}