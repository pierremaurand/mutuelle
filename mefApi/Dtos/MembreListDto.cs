namespace WebApi.Dtos
{
    public class MembreListDto
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateAdhesion { get; set; }
        public string? Agence { get; set; }
        public Boolean? EstActif { get; set; }
    }
}