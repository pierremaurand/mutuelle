namespace WebApi.Dtos
{
    public class EcheanceAvanceDto
    {
        public int Id { get; set; }
        public string DateEcheance { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public bool EstPaye { get; set; }
        public bool EstNouveau { get; set; }
    }
}