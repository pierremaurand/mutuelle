using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class CreditDebourse : BaseEntity
    {
        public int CreditId { get; set; } = 0;
        public Credit? Credit { get; set; }
        public decimal MontantCapital { get; set; } = 0;
        public decimal MontantCommission { get; set; } = 0;
        public decimal MontantInteret { get; set; } = 0;
        public int NombreEcheances { get; set; } = 0;
        public string DateDebut { get; set; } = string.Empty;
        public string DateFin { get; set; } = string.Empty;
    }
}