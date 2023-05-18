using System.Collections.Generic;

namespace mefApi.Dtos
{
    public class InfosCompteDto 
    {
        public int Id { get; set; } = 0; 
        public ICollection<MvtCompteDto> MvtComptes { get; set; } = new List<MvtCompteDto>();
    }
}