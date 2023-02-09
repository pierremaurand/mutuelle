namespace mefApi.Dtos
{
    public class CompteMembreDto
    {
        public int Id { get; set; }
        public int MembreId { get; set; }
        public MembreDto? Membre { get; set; }
        public bool EstActif { get; set; }
        public IEnumerable<MvtCompteDto>? MvtComptes { get; set; } 
    }
}