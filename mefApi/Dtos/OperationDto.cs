using mefApi.Models;

namespace mefApi.Dtos
{
    public class OperationDto
    {
        public int CompteComptableId { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public decimal Taux { get; set; }
    }
}