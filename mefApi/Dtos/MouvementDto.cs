using mefApi.Models;

namespace mefApi.Dtos
{
    public class MouvementDto
    {
        public int Id { get; set; } = 0;
        public string DateMvt { get; set; } = string.Empty;
        public TypeOperation TypeOperation { get; set;} = 0;
        public int GabaritId { get; set; } = 0;
        public string Libelle { get; set; } = string.Empty;
        public decimal Montant { get; set; } = 0;
    }
}