namespace mefApi.Models
{
    public class Operation 
    {
        public int Id { get; set; }
        public int CompteComptableId { get; set; }
        public CompteComptable? CompteComptable { get; set; }
        public int GabaritId { get; set; }
        public Gabarit? Gabarit { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public decimal Taux { get; set; }
    }
}