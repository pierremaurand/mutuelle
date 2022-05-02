namespace WebApi.Models
{
    public class Credit : BaseEntity
    {
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public decimal Interets { get; set; }
        public int MembreId { get; set; } 
        public Membre Membre { get; set; } = new Membre{};
        public ICollection<EcheanceCredit> EcheanceCredits { get; set; } = new List<EcheanceCredit>();
    }
}