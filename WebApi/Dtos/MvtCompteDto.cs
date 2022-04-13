namespace WebApi.Dtos
{
    public class MvtCompteDto
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public int CompteId { get; set; }
        public bool EstDebit { get; set; }
        public decimal Montant { get; set; }
        public string Libelle { get; set; } = string.Empty;
    }
}