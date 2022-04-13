namespace WebApi.Dtos
{
    public class AdhesionDto
    {
        public int Id { get; set; }
        public int MembreId { get; set; }
        public decimal FraisAdhesion { get; set; }
        public DateTime DateAdhesion { get; set; }
    }
}