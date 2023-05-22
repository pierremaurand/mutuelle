using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class MvtCreditDebourseDto
    {
        public int Id { get; set; } = 0;
        public int MouvementId { get; set; } = 0;
        public int CreditDebourseId { get; set; } = 0;
    }
}