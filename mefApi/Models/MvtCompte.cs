using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class MvtCompte : BaseEntity
    {
        public int MouvementId { get; set; } = 0;
        public Mouvement? Mouvement { get; set; } 
        public int MembreId { get; set; } = 0;
        public Membre? Membre { get; set; } 
    }
}