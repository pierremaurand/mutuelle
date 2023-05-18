using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class EcheanceAvanceDto
    {
        public int Id { get; set; } = 0;
        [Required]
        public int AvanceId { get; set; } = 0;
        [Required]
        public int MoisId { get; set; } = 0;
        [Required]
        public int Annee { get; set; } = 0;
        [Required]
        public decimal Montant { get; set; } = 0;
        public bool EstPaye { get; set; } = false;
    }
}