namespace WebApi.Models
{
    public class Adhesion : BaseEntity
    {
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public decimal FraisAdhesion { get; set; }
        public DateTime DateAdhesion { get; set; }
    }
}