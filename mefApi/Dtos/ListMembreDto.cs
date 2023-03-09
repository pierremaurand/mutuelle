using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class ListMembreDto : MembreDto
    {
        public string? Sexe { get; set; }
        public string? Poste { get; set; }
        public string? LieuAffectation { get; set; }
    }
}