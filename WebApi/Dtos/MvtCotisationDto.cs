namespace WebApi.Dtos
{
    public class MvtCotisationDto
    {
        public int Id { get; set; }
        public int MembreId { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public bool EstDebit { get; set; }
        public decimal Montant { get; set; }
        public int CotisationId { get; set; }
    }
}