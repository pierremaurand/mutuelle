using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class MouvementDto
    {
        public int Id { get; set; } = 0;
        public string DateMvt { get; set; } = string.Empty;
        public TypeOperation TypeOperation { get; set;} = 0;
        public int GabaritId { get; set; } 
        public string Libelle { get; set; } = string.Empty;
        public decimal Montant { get; set; } = 0;
    }
}