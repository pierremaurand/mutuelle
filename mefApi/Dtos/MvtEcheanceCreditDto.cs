using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class MvtEcheanceCreditDto
    {
        public int Id { get; set; } = 0;
        public int MouvementId { get; set; } = 0;
        public int EcheanceCreditId { get; set; } = 0;
    }
}