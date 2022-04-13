namespace WebApi.Dtos
{
    public class CompteDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Libelle { get; set; } = string.Empty;
    }
}