namespace WebApi.Models
{
    public class Cotisation : BaseEntity
    {
        public string Periode { get; set; } = string.Empty;
        public int MembreId { get; set; } 
        public Membre Membre { get; set; } = new Membre{};
        public decimal Montant { get; set; }
        public Boolean EstValide { get; set; }
    }
}