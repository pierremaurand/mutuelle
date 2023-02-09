using mefApi.Models;

namespace mefApi.Dtos
{
    public class MvtCompteDto
    {
        public int Id { get; set; }
        public int CompteId { get; set; }
        public CompteMembreDto? Compte { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public int GabaritId { get; set; }
        public GabaritDto? Gabarit { get; set; }
        public string? Libelle { get; set; }
        public decimal Montant { get; set; }
        public string? DateMvt { get; set; }
    }
}