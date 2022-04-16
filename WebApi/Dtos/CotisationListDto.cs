namespace WebApi.Dtos
{
    public class CotisationListDto
    {
        public int Id { get; set; }
        public int PeriodeId { get; set; }
        public string Periode { get; set; } = string.Empty;
        public int MembreId { get; set; } 
        public decimal Montant { get; set; }
    }
}