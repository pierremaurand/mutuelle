namespace WebApi.Models
{
    public class Cotisation : BaseEntity
    {
        public int PeriodeId { get; set; }
        public Periode? Periode { get; set; }
        public int MembreId { get; set; } 
        public Membre? Membre { get; set; }
        public decimal Montant { get; set; }
    }
}