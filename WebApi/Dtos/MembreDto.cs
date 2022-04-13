namespace WebApi.Dtos
{
    public class MembreDto
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int? SexeId { get; set; }
        public string? Sexe { get; set; }
        public string? Photo { get; set; }
        public int? AgenceId { get; set; }
        public string? Agence { get; set; }
        public int? ServiceId { get; set; }
        public string? Service { get; set; }
        public Boolean? EstActif { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}