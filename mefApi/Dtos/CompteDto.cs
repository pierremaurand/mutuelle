using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Dtos
{
    public class CompteDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Le membre est obligatoire")]
        public int? MembreId { get; set; }
        public bool? EstActif { get; set; }
    }
}