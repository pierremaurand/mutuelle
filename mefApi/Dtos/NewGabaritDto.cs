namespace mefApi.Dtos
{
    public class NewGabaritDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty;
        public ICollection<NewOperationDto>? Operations { get; set; }
    }
}