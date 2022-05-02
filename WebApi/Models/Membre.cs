namespace WebApi.Models
{
    public class Membre : BaseEntity
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public int SexeId { get; set; }
        public Sexe Sexe { get; set; } = new Sexe{};
        public string? Photo { get; set; }
        public int AgenceId { get; set; }
        public Agence Agence { get; set; } = new Agence{};
        public int ServiceId { get; set; }
        public Service Service { get; set; } = new Service{};
        public bool EstActif { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Cotisation> Cotisations { get; set; } = new List<Cotisation>();
        public ICollection<Avance> Avances { get; set; } = new List<Avance>();
        public ICollection<Credit> Credits { get; set; } = new List<Credit>();
    }
}