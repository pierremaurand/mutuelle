using System.ComponentModel.DataAnnotations;

namespace hspaApi2.Models
{
    public class FurnishingType: BaseEntity
    {
        [Required]
        public string? Name { get; set; } 
    }
}