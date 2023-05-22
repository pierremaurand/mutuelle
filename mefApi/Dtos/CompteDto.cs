namespace mefApi.Dtos
{
    public class CompteDto
    {
        public MembreListDto Membre { get; set; } = new MembreListDto();
        public decimal Solde { get; set; } = 0;
    }
}