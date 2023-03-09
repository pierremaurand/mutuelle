using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class ListAvancesMembreDto : ListMembreDto
    {
        public decimal? Avances { get; set; }
    }
}