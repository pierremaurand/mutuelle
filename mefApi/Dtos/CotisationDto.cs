namespace WebApi.Dtos
{
    public class CotisationDto
    {
        public int? Id { get; set; }
        public string? Periode { get; set; }
        public int? MembreId { get; set; }
        public decimal? Montant { get; set; }
        public Boolean? EstValide { get; set; }
    }
}