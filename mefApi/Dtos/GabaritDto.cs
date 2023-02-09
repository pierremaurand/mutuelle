using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class GabaritDto
    {
        public int Id { get; set; }
        public string? Libelle { get; set; }
        public ICollection<OperationDto>? Operations { get; set; }
        public int CreePar { get; set; }
        public DateTime ModifieLe { get; set; }
        public int ModifiePar { get; set; }
    }
}