using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class CotisationsMembre
    {
        public int? Id { get; set; }
        public string? Nom { get; set; }
        public bool? EstActif { get; set; }
        public ICollection<CotisationDto>? Cotisations { get; set; }
        public decimal Solde { get; set; }
    }
}