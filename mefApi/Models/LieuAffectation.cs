using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class LieuAffectation : BaseEntity
    {
        [Required]
        public string? Lieu { get; set; }
        public int? PaieId { get; set; }
    }
}