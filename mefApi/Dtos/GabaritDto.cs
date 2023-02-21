using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class GabaritDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le libellé est obligatoire")] 
        public string? Libelle { get; set; }
    }
}