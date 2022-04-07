using CloudinaryDotNet.Actions;

namespace hspaApi2.Interfaces
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
         Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}