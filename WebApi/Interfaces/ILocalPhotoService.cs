using hspaApi2.Models;

namespace hspaApi2.Interfaces
{
    public interface ILocalPhotoService
    {
        Task<LocalImageUploadResult> UploadPhotoAsync(IFormFile photo);
        Task<LocalDeletionResult> DeletePhotoAsync(string publicId);
    }
}