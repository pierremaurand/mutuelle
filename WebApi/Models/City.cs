using System.ComponentModel.DataAnnotations;

namespace hspaApi2.Models
{
    public class City: BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Country { get; set; }
    }
}