using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class CreditDto
    {
        public int Id { get; set; }
        [Required]
        public int? MembreId { get; set; }
        [Required]
        public decimal? MontantCapital { get; set; }
        [Required]
        public decimal? MontantCommission { get; set; }
        [Required]
        public decimal? MontantInteret { get; set; }
        public int? NombreEcheances { get; set; }
        [Required]
        public string? DateEnregistrement { get; set; }
        public string? DateDeblocage { get; set; }
        public string? DateSolde { get; set; }
    }
}