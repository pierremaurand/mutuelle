namespace WebApi.Models
{
    public class Periode : BaseEntity
    {
        public string Libelle { get; set; } = string.Empty;
        public ICollection<Cotisation>? Cotisations { get; set; }
    }
}