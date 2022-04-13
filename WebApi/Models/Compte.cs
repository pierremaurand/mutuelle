namespace WebApi.Models
{
    public class Compte : BaseEntity
    {
        public int Numero { get; set; }
        public string Libelle { get; set; } = string.Empty;
    }
}