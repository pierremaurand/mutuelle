namespace WebApi.Models
{
    public class DemandeAvance : BaseEntity
    {
        public DateTime DateDemande { get; set; }
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public decimal MontantSolicite { get; set; }
        public decimal? MontantApprouve { get; set; }
        public int NombreEcheance { get; set; }
        public bool? EstApprouve { get; set; }
    }
}