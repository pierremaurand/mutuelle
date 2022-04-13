namespace WebApi.Models
{
    public class Cotisation : BaseEntity
    {
        public int Mois { get; set; }
        public int Annee { get; set; }
        public ICollection<MvtCotisation>? MvtCotisations { get; set; }
    }
}