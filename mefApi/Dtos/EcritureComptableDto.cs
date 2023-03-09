using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class EcritureComptableDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Le libellé est obligatoire")]
        public string? Libelle { get; set; }
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal? Montant { get; set; }
        public int? MvtCompteId { get; set; }
        public bool? EstApplique { get; set; }
    }
}