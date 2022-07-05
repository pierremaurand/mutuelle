namespace WebApi.Dtos
{
    public class CreditDto
    {
        public int Id { get; set; }
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public decimal Capital { get; set; }
        public decimal Interet { get; set; }
        public decimal Commission { get; set; }
        public ICollection<EcheanceCreditDto> EcheanceCredits { get; set; } = new List<EcheanceCreditDto>();
    }
}