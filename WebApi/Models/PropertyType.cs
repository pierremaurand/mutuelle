using System.ComponentModel.DataAnnotations;

namespace hspaApi2.Models
{
    public class PropertyType: BaseEntity
    {
        [Required]
        public string? Name { get; set; }
    }
}