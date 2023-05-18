using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class AvanceDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage ="Le membre est obligatoire")]
        public int MembreId { get; set; } = 0;
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal Montant { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
        [Required(ErrorMessage ="La date d'enregistrement est obligatoire")]
        public string DateEnregistrement { get; set; } = string.Empty;
        public string DateDeblocage { get; set; } = string.Empty;
        public string DateSolde { get; set; } = string.Empty;
    }
}