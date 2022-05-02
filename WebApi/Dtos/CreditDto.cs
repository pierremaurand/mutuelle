namespace WebApi.Dtos
{
    public class CreditDto
    {
        public int Id { get; set; }
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
        public decimal Montant { get; set; }
        public decimal Interets { get; set; }
        public ICollection<EcheanceCreditDto> EcheanceCreditDtos { get; set; } = new List<EcheanceCreditDto>();
    }
}