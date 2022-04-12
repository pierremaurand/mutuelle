namespace WebApi.Dtos
{
    public class MembreListDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Sexe { get; set; }
        public string? Photo { get; set; }
        public string? Agence { get; set; }
        public string? Service { get; set; }
        public Boolean EstActif { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}