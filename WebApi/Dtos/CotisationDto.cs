namespace WebApi.Dtos
{
    public class CotisationDto
    {
        public int Id { get; set; }
        public int PeriodeId { get; set; }
        public int MembreId { get; set; } 
        public decimal Montant { get; set; }
    }
}