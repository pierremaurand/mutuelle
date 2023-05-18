using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class CotisationDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Le membre est obligatoire")]
        public int MembreId { get; set; } = 0;
        [Required(ErrorMessage ="Le mois est obligatoire")]
        public int MoisId { get; set; } = 0;
        [Required(ErrorMessage ="L'année est obligatoire")]
        public int Annee { get; set; } = 0;
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal Montant { get; set; } = 0;
        public ICollection<MvtCompteDto> MvtComptes { get; set; } = new List<MvtCompteDto>();
    }
}