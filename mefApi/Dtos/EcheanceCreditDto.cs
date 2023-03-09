using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class EcheanceCreditDto
    {
        public int Id { get; set; }
        [Required]
        public int? CreditId { get; set; }
        [Required]
        public int? MoisId { get; set; }
        [Required]
        public int? Annee { get; set; }
        [Required]
        public decimal? MontantCapital { get; set; }
        [Required]
        public decimal? MontantInteret { get; set; }
        public bool? EstPaye { get; set; }
    }
}