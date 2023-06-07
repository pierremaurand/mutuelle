using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class CotisationsMembre
    {
        public MembreDto? Membre { get; set; } 
        public ICollection<CotisationDto>? Cotisations { get; set; } 
    }
}