using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Poste: BaseEntity
    {
        public string? Libelle { get; set; }
    }
}