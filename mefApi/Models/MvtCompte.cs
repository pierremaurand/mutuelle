using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtCompte : BaseEntity
    {
        public int CompteId { get; set; }
        public Compte? Compte { get; set; }
        public TypeOperation TypeOperation { get; set;}
        public int GabaritId { get; set; }
        public Gabarit? Gabarit { get; set; }
        public string? Libelle { get; set; }
        public decimal Montant { get; set; }
        public string? DateMvt { get; set; }
    }
}