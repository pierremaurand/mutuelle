using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class AvanceDebourse : BaseEntity
    {
        public int AvanceId { get; set; }
        public Avance? Avance { get; set; }
        public decimal MontantDebourse { get; set; }
        public int NombreEcheances { get; set; } 
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
    }
}