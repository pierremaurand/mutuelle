using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class CotisationDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le membre est obligatoire")]
        public int MembreId { get; set; }
        [Required(ErrorMessage ="Le mois est obligatoire")]
        public int MoisId { get; set; }
        [Required(ErrorMessage ="L'année est obligatoire")]
        public int Annee { get; set; }
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal Montant { get; set; }
        public ICollection<MvtCompteDto>? MvtComptes { get; set; }
    }
}