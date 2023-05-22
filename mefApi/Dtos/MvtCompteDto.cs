using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class MvtCompteDto
    {
        public int Id { get; set; } = 0;
        public int MouvementId { get; set; } = 0;
        public int MembreId { get; set; } = 0;
    }
}