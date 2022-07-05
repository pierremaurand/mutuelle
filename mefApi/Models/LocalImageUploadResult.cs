namespace WebApi.Models
{
    public class LocalImageUploadResult
    {
        public string? ImageUrl { get; set; }
        public string? PublicId { get; set; }
        public LocalError? Error { get; set; }
    }
}