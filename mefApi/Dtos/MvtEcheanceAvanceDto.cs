using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class MvtEcheanceAvanceDto
    {
        public int Id { get; set; } = 0;
        public int MouvementId { get; set; } = 0;
        public int EcheanceAvanceId { get; set; } = 0;
    }
}