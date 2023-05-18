using System.ComponentModel.DataAnnotations;
using mefApi.Models;

namespace mefApi.Dtos
{
    public class MvtCompteDto
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Le membre est obligatoire")]
        public int MembreId { get; set; } = 0;
        [Required(ErrorMessage = "Le type d'opération est obligatoire")] 
        public TypeOperation TypeOperation { get; set;} = 0;
        [Required(ErrorMessage = "Le gabarit est obligatoire")] 
        public int GabaritId { get; set; } = 0;
        [Required(ErrorMessage = "Le libellé est obligatoire")] 
        public string Libelle { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le montant est obligatoire")] 
        public decimal Montant { get; set; } = 0;
        [Required(ErrorMessage = "La date est obligatoire")] 
        public string DateMvt { get; set; } = string.Empty;
        public int AvanceId { get; set; } = 0;
        public int CreditId { get; set; } = 0;
        public int CotisationId { get; set; } = 0;
        public int EcheanceAvanceId { get; set; } = 0;
        public int EcheanceCreditId { get; set; } = 0;
        public int EcritureComptableId { get; set; } = 0;
    }
}