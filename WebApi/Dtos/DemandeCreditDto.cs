namespace WebApi.Dtos
{
    public class DemandeCreditDto
    {
        public int Id { get; set; }
        public DateTime DateDemande { get; set; }
        public int MembreId { get; set; }
        public decimal MontantSolicite { get; set; }
        public decimal? MontantApprouve { get; set; }
        public int NombreEcheance { get; set; }
        public bool? EstApprouve { get; set; }
    }
}