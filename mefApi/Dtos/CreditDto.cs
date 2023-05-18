using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class CreditDto
    {
        public int Id { get; set; }
        [Required]
        public int MembreId { get; set; } = 0;
        [Required]
        public decimal MontantCapital { get; set; } = 0;
        [Required]
        public decimal MontantCommission { get; set; } = 0;
        [Required]
        public decimal MontantInteret { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
        [Required]
        public string DateEnregistrement { get; set; } = string.Empty;
        public string DateDeblocage { get; set; } = string.Empty;
        public string DateSolde { get; set; } = string.Empty;
    }
}