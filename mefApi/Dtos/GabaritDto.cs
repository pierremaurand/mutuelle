using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class GabaritDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le libellé est obligatoire")] 
        public string? Libelle { get; set; }
        [Required(ErrorMessage = "Le type de mouvement est obligatoire")] 
        public TypeMouvement? TypeMouvement { get; set; }
        public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    }
}