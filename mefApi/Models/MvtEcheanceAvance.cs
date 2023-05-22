using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtEcheanceAvance : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int EcheanceAvanceId { get; set; } = 0;
        public EcheanceAvance? EcheanceAvance { get; set; } 
    }
}