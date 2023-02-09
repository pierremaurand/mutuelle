namespace mefApi.Models
{
    public class Gabarit : BaseEntity
    {
        public string? Libelle { get; set; }
        public IEnumerable<Operation>? Operations { get; set; } 
    }
}