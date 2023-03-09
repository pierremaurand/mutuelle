using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class EcheanceAvanceDto
    {
        public int Id { get; set; }
        [Required]
        public int? AvanceId { get; set; }
        [Required]
        public int? MoisId { get; set; }
        [Required]
        public int? Annee { get; set; }
        [Required]
        public decimal? Montant { get; set; }
        public bool? EstPaye { get; set; }
    }
}