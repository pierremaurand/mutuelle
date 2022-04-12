namespace WebApi.Dtos
{
    public class PhotoDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }
}