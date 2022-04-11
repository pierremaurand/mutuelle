using System.ComponentModel.DataAnnotations;
using hspaApi2.Models;

namespace WebApi.Models
{
    public class Sexe: BaseEntity
    {
        [Required]
        public string? Nom { get; set; }
    }
}