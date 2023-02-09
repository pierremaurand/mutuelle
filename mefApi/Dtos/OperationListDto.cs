using mefApi.Models;

namespace mefApi.Dtos
{
    public class OperationListDto
    {
        public int Id { get; set; }
        public int CompteComptableId { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public decimal Taux { get; set; }
    }
}