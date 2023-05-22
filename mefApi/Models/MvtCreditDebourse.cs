using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtCreditDebourse : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int CreditDebourseId { get; set; } = 0;
        public CreditDebourse? CreditDebourse { get; set; } 
    }
}