namespace mefApi.Dtos
{
    public class InfosMembreDto : ListMembreDto
    {
        public ICollection<MvtCompteDto> MvtComptes { get; set; } = new List<MvtCompteDto>();
        public ICollection<AvanceDto> Avances { get; set; } = new List<AvanceDto>();
        public ICollection<CreditDto> Credits { get; set; } = new List<CreditDto>();
        public ICollection<CotisationDto> Cotisations { get; set; } = new List<CotisationDto>();
    }
}