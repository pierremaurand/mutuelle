namespace WebApi.Dtos
{
    public class CotisationDto
    {
        public int Id { get; set; }
        public string Periode { get; set; } = string.Empty;
        public decimal Montant { get; set; }
    }
}