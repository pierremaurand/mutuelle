namespace mefApi.Dtos
{
    public class InfosCotisationDto
    {
        public int Id; 
        public ICollection<CotisationDto> Cotisations { get; set; } = new List<CotisationDto>();
    }
}