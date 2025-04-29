using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mefapi.Enums;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class CotisationDto
    {
        public int Id { get; set; }
        public int MembreId { get; set; }
        public Mois Mois { get; set; }
        public int Annee { get; set; }
        public decimal Montant { get; set; }
    }
}