using System.ComponentModel.DataAnnotations;

namespace mefApi.Dtos
{
    public class MoisDto
    {
        public int? Id { get; set; }
        [MaxLength(2)]
        public string? Valeur { get; set; }
        [MaxLength(10)]
        public string? Libelle { get; set; }
    }
}