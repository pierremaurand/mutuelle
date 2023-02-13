using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class PosteDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le libellé du poste est obligatoire")] 
        public string? Libelle { get; set; }
    }
}