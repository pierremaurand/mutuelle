using System;
using System.ComponentModel.DataAnnotations;

namespace hspaApi2.Models
{
    public class Agence: BaseEntity
    {
        [Required]
        public string? Nom { get; set; }
    }
}