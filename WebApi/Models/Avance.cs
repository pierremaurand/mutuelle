namespace WebApi.Models
{
    public class Avance : BaseEntity
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Montant { get; set; }
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public ICollection<EcheanceAvance>? EcheanceAvances { get; set; }
    }
}