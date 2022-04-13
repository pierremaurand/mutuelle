namespace WebApi.Dtos
{
    public class EcheanceAvanceDto
    {
        public int Id { get; set; }
        public DateTime DateEcheance { get; set; }
        public decimal Montant { get; set; }
        public bool EstPaye { get; set; }
        public int AvanceId { get; set; }
    }
}