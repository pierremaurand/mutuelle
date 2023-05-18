using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class CreditDebourse : BaseEntity
    {
        public int CreditId { get; set; }
        public Credit? Credit { get; set; }
        public decimal MontantCapital { get; set; } = 0;
        public decimal MontantCommission { get; set; } = 0;
        public decimal MontantInteret { get; set; } = 0;
        public int NombreEcheances { get; set; } 
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
    }
}