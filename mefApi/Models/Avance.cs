namespace WebApi.Models
{
    public class Avance : BaseEntity
    {
        public string DateDeblocage { get; set; } = string.Empty;
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public int MembreId { get; set; } 
        public Membre Membre { get; set; } = new Membre{};
        public Boolean EstValide { get; set; }
        public ICollection<EcheanceAvance> EcheanceAvances { get; set; } = new List<EcheanceAvance>();
    }
}