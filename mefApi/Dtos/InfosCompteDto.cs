using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class InfosCompteDto 
    {
        public int Id; 
        public ICollection<MvtCompteDto> MvtComptes { get; set; } = new List<MvtCompteDto>();
    }
}