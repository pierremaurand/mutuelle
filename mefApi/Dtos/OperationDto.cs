using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class OperationDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le gabarit est obligatoire")] 
        public int? CompteComptableId { get; set; }
        [Required(ErrorMessage = "Le type d'opération est obligatoire")] 
        public TypeOperation? TypeOperation { get; set;}
        [Required(ErrorMessage = "Le taux est obligatoire")] 
        public decimal? Taux { get; set; }
    }
}