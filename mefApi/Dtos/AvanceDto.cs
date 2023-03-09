using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class AvanceDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Le membre est obligatoire")]
        public int? MembreId { get; set; }
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal Montant { get; set; }
        public int NombreEcheances { get; set; }
        [Required(ErrorMessage ="La date d'enregistrement est obligatoire")]
        public string? DateEnregistrement { get; set; }
        public string? DateDeblocage { get; set; }
        public string? DateSolde { get; set; }
    }
}