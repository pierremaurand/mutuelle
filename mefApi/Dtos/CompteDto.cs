using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class CompteDto
    {
        public int Id { get; set; } = 0;
        public MembreDto Membre { get; set; } = new MembreDto();
        public decimal Solde { get; set; } = 0;
    }
}