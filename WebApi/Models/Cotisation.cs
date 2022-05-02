namespace WebApi.Models
{
    public class Cotisation : BaseEntity
    {
        public int PeriodeId { get; set; }
        public string Periode { get; set; } = string.Empty;
        public int MembreId { get; set; } 
        public Membre Membre { get; set; } = new Membre{};
        public decimal Montant { get; set; }
    }
}