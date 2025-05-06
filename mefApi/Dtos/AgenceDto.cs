using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class AgenceDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string? Nom { get; set; }
    }
}