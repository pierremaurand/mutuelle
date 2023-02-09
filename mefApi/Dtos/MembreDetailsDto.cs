namespace mefApi.Dtos
{
    public class MembreDetailsDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public int? PersonnelId { get; set; }
        public bool? EstActif { get; set; }
        public int? SexeId { get; set; }
        public string? SexeNom { get; set; }
        public int? PosteId { get; set; }
        public string? PosteLibelle { get; set; }
        public string? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }
        public string? Photo { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public int CreePar { get; set; }
        public DateTime ModifieLe { get; set; }
        public int ModifiePar { get; set; }
    }
}