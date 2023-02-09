namespace mefApi.Dtos
{
    public class MembreListDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public bool? EstActif { get; set; }
        public int? SexeId { get; set; }
        public string? SexeNom { get; set; }
        public string? DateNaissance { get; set; }
        public string? LieuNaissance { get; set; }
        public int? PosteId { get; set; }
        public string? PosteLibelle { get; set; }
        public string? Photo { get; set; }
        public string? Contact { get; set; }
    }
}