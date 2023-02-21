using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class MvtCompteDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le type d'opération est obligatoire")] 
        public TypeOperation? TypeOperation { get; set;}
        [Required(ErrorMessage = "Le gabarit est obligatoire")] 
        public int? GabaritId { get; set; }
        [Required(ErrorMessage = "Le libellé est obligatoire")] 
        public string? Libelle { get; set; }
        [Required(ErrorMessage = "Le montant est obligatoire")] 
        public decimal? Montant { get; set; }
        [Required(ErrorMessage = "La date du mouvement est obligatoire")] 
        public string? DateMvt { get; set; }
    }
}