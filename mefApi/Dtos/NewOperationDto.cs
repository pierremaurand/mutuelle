using mefApi.Models;

namespace mefApi.Dtos
{
    public class NewOperationDto
    {
        public int CompteComptableId { get; set; }
        public int GabaritId { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public decimal Taux { get; set; }
    }
}