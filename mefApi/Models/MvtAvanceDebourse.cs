using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtAvanceDebourse : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int AvanceDebourseId { get; set; } = 0;
        public AvanceDebourse? AvanceDebourse { get; set; } 
    }
}