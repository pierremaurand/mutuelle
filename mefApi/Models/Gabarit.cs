namespace mefApi.Models
{
    public class Gabarit : BaseEntity
    {
        public string? Libelle { get; set; }
        public Operation[]? Operations { get; set; }
    }
}