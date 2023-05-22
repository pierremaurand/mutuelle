using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class AvanceDebourse : BaseEntity
    {
        public int AvanceId { get; set; } = 0;
        public Avance? Avance { get; set; }
        public decimal MontantDebourse { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
    }
}