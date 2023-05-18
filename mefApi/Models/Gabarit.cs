using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mefApi.Models
{
    public class Gabarit : BaseEntity
    {
        [Required]
        public string Libelle { get; set; } = string.Empty;
        [Required]
        public TypeMouvement TypeMouvement { get; set; } 
    }
}