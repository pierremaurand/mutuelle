using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class CompteComptable : BaseEntity
    {
        public string? Compte { get; set; }
        public string? Libelle { get; set; }
    }
}