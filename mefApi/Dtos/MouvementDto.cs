using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class MouvementDto
    {
        public int Id { get; set; } = 0;
        [Required]
        public string DateMvt { get; set; } = string.Empty;
        [Required]
        public TypeOperation TypeOperation { get; set;} = 0;
        [Required]
        public int GabaritId { get; set; } 
        [Required]
        public string Libelle { get; set; } = string.Empty;
        [Required]
        public decimal Montant { get; set; } = 0;
    }
}