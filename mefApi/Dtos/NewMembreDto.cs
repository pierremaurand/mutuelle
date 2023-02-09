namespace mefApi.Dtos
{
    public class NewMembreDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int PersonnelId { get; set; }
        public bool EstActif { get; set; }
        public int SexeId { get; set; }
        public SexeDto? Sexe { get; set; }
        public int PosteId { get; set; }
        public PosteDto? Poste { get; set; }
        public string? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }
        public string Contact { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}