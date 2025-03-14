using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class GabaritDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Le libellé est obligatoire")] 
        public string Libelle { get; set; } = string.Empty;
        public bool EstActif { get; set; } = false;
    }
}