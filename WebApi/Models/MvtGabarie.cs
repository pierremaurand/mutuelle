using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("MvtGabaries")]
    public class MvtGabarie : BaseEntity
    {
        public bool EstDebit { get; set; }
        public bool EstFixe { get; set; }
        public decimal Valeur { get; set; }
        public int CompteId { get; set; }
        public Compte? Compte { get; set; }
        public int GabarieId { get; set; }
        public Gabarie? Gabarie { get; set; }
    }
}