namespace WebApi.Models
{
    public class Credit : BaseEntity
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Montant { get; set; }
        public decimal Interets { get; set; }
        public ICollection<EcheanceCredit>? EcheanceCredits { get; set; }
    }
}