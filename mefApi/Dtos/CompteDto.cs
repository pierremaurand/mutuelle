using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class CompteDto
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public string? Photo { get; set; }
        public decimal? Solde { get; set; }
    }
}