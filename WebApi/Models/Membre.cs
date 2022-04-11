using System.ComponentModel.DataAnnotations;
using hspaApi2.Models;

namespace WebApi.Models
{
    public class Membre : BaseEntity
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int SexeId { get; set; }
        public Sexe? Sexe { get; set; }
        public DateTime DateAdhesion { get; set; }
        public string? Photo { get; set; }
        public int AgenceId { get; set; }
        public Agence? Agence { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public Boolean EstActif { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}