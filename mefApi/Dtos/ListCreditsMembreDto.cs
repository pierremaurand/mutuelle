using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class ListCreditsMembreDto : ListMembreDto
    {
        public decimal? Credits { get; set; }
    }
}