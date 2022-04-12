using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Agence: BaseEntity
    {
        [Required]
        public string? Nom { get; set; }
    }
}