using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtEcheanceCredit : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int EcheanceCreditId { get; set; } = 0;
        public EcheanceCredit? EcheanceCredit { get; set; } 
    }
}