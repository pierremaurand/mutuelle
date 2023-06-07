using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class EcheanceAvanceDto
    {
        public int Id { get; set; } = 0;
        [Required]
        public string DateEcheance { get; set; } = string.Empty;
        [Required]
        public decimal MontantEcheance { get; set; } = 0;
    }
}