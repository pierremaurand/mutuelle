using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class ServiceDto
    {
        public int? Id { get; set; }
        [Required]
        public string? Nom { get; set; }
    }
}