namespace mefApi.Dtos
{
    public class CompteComptableDto
    {
        public int Id { get; set; }
        public string? Compte { get; set; }
        public string? Libelle { get; set; }
        public int CreePar { get; set; }
        public DateTime ModifieLe { get; set; }
        public int ModifiePar { get; set; }
    }
}