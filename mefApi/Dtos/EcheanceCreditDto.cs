using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class EcheanceCreditDto
    {
        public int Id { get; set; } = 0;
        [Required]
        public int CreditId { get; set; } = 0;
        [Required]
        public int MoisId { get; set; } = 0;
        [Required]
        public int Annee { get; set; } = 0;
        [Required]
        public decimal MontantCapital { get; set; } = 0;
        [Required]
        public decimal MontantInteret { get; set; } = 0;
        public bool EstPaye { get; set; } = false;
    }
}