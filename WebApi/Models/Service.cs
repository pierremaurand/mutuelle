using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Service: BaseEntity
    {
        [Required]
        public string Nom { get; set; } = string.Empty;
    }
}