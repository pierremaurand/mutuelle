using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class SexeDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le nom du sexe est obligatoire")] 
        public string? Nom { get; set; }
    }
}