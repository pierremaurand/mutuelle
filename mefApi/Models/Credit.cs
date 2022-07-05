namespace WebApi.Models
{
    public class Credit : BaseEntity
    {
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public decimal MontantCapital { get; set; }
        public decimal Interet { get; set; }
        public decimal Commission { get; set; }
        public Boolean EstValide { get; set; }
        public int MembreId { get; set; } 
        public Membre Membre { get; set; } = new Membre{};
        public ICollection<EcheanceCredit> EcheanceCredits { get; set; } = new List<EcheanceCredit>();
    }
}