namespace mefApi.Dtos
{
    public class CompteDto
    {
        public MembreDto Membre { get; set; } = new MembreDto();
        public ICollection<MouvementDto>? Mouvements { get; set; } 
        public decimal Solde { get; set; } = 0;
    }
}