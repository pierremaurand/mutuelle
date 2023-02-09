namespace mefApi.Models
{
    public class Compte : BaseEntity
    {
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public bool EstActif { get; set; }
        public IEnumerable<MvtCompte>? MvtComptes { get; set; } 
    }
}