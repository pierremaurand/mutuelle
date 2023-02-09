namespace mefApi.Dtos
{
    public class GabaritListDto
    {
        public int Id { get; set; }
        public string? Libelle { get; set; }
        public ICollection<OperationListDto>? Operations { get; set; }
    }
}