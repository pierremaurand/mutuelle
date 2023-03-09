using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class ListMvtsMembreDto : ListMembreDto
    {
        public decimal? MvtComptes { get; set; }
    }
}