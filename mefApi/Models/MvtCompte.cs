namespace WebApi.Models
{
    public class MvtCompte : BaseEntity
    {
        public DateTime DateCreation { get; set; }
        public int CompteId { get; set; }
        public Compte? Compte { get; set; }
        public bool EstDebit { get; set; }
        public decimal Montant { get; set; }
        public string Libelle { get; set; } = string.Empty;
    }
}