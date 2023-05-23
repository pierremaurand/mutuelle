using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class CotisationMembreDto
    {
        public MembreListDto Membre { get; set; } = new MembreListDto();
        public decimal Solde { get; set; } = 0;
    }
}