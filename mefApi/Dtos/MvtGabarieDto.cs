namespace WebApi.Dtos
{
    public class MvtGabarieDto
    {
        public int Id { get; set; }
        public bool EstDebit { get; set; }
        public bool EstFixe { get; set; }
        public decimal Valeur { get; set; }
        public int CompteId { get; set; }
        public int GabarieId { get; set; }
    }
}