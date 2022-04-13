namespace WebApi.Dtos
{
    public class CreditDto
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Montant { get; set; }
        public decimal Interets { get; set; }
        public int DemandeCreditId { get; set; }
    }
}