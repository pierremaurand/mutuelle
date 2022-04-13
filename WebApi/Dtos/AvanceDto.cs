namespace WebApi.Dtos
{
    public class AvanceDto
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Montant { get; set; }
        public int DemandeAvanceId { get; set; }
    }
}