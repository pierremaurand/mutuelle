using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class ListCotisationsMembreDto : ListMembreDto
    {
        public decimal? Cotisations { get; set; }
    }
}