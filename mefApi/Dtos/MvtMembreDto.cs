namespace mefApi.Dtos
{
    public class MvtMembreDto
    {
        public ICollection<MvtCompteDto> MvtComptes { get; set; } = new List<MvtCompteDto>();
    }
}