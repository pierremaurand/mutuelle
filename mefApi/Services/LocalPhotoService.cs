using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class LocalPhotoService : ILocalPhotoService
    {
         private readonly IWebHostEnvironment env;

        public LocalPhotoService(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task<LocalDeletionResult> DeletePhotoAsync(string publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploadResult = new LocalImageUploadResult();

            if(photo.Length > 0) {
                try {
                    string wwwrootpath = env.WebRootPath;
                    var imagePath = @"assets\images\";
                    var imageWebPath = @"assets/images/";
                    var extension = Path.GetExtension(photo.FileName);
                    var fileName = Path.GetRandomFileName();
                    var publicId = Path.GetFileName(fileName);
                    var imageName = publicId + extension;
                    var relativeImagePath = imagePath + imageName;
                    var absImagePath = Path.Combine(wwwrootpath, relativeImagePath);

                    using var image = await Image.LoadAsync(photo.OpenReadStream());
                    image.Mutate(x => x.Resize(200, 200));
                    await image.SaveAsync(absImagePath);
                    uploadResult.ImageUrl = imageWebPath + imageName;
                    uploadResult.PublicId = publicId;
                } catch(Exception ex) {
                    uploadResult.Error = new LocalError();
                    uploadResult.Error.Message = ex.Message;
                }
                
            }

            return uploadResult;
        }

    }
}