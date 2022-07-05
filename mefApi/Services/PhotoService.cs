using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary cloudinary;
        private readonly IMapper mapper;
        public PhotoService(IConfiguration config, IMapper mapper)
        {
            Account account = new Account(
                config.GetSection("CloudinarySettings:CloudName").Value,
                config.GetSection("CloudinarySettings:ApiKey").Value,
                config.GetSection("CloudinarySettings:ApiSecret").Value
            );

            cloudinary = new Cloudinary(account);
            this.mapper = mapper;
        }

        public Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if(photo.Length > 0) 
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams 
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation()
                        .Height(500).Width(800)
                };
                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        
    }
}