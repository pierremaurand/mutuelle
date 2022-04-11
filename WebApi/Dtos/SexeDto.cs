using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class SexeDto
    {
        public int? Id { get; set; }
        [Required]
        public string? Nom { get; set; }
    }
}