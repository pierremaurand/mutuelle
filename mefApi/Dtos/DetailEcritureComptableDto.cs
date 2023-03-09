using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class DetailEcritureComptableDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="L'écriture comptable est obligatoire")]
        public int? EcritureComptableId { get; set; }
        [Required(ErrorMessage ="Le compte comptable est obligatoire")]
        public int? CompteComptableId { get; set; }
        [Required(ErrorMessage ="Le type d'opération est obligatoire")]
        public TypeOperation? TypeOperation { get; set; }
        [Required(ErrorMessage ="Le montant est obligatoire")]
        public decimal? Montant { get; set; }
    }
}