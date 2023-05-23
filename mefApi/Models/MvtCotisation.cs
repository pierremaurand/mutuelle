using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtCotisation : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int CotisationId { get; set; } = 0;
        public Cotisation? Cotisation { get; set; } 
    }
}