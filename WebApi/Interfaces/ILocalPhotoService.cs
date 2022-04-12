using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ILocalPhotoService
    {
        Task<LocalImageUploadResult> UploadPhotoAsync(IFormFile photo);
        Task<LocalDeletionResult> DeletePhotoAsync(string publicId);
    }
}