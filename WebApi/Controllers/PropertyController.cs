using AutoMapper;
using hspaApi2.Dtos;
using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace hspaApi2.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService; 
        private readonly ILocalPhotoService localPhotoService;
        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoService photoService, ILocalPhotoService localPhotoService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.photoService = photoService;
            this.localPhotoService = localPhotoService;
        }

        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent) {
            var properties = await uow.PropertyRepository.GetAllAsync(sellRent);
            if(properties is null) {
                return NotFound();
            }
            var propertiesDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertiesDto);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id) {
            var property = await uow.PropertyRepository.FindByIdAsync(id);
            if(property is null) {
                return NotFound();
            }
            var propertyDto = mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDto);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyDto propertyDto) {
            var property = mapper.Map<Property>(propertyDto);
            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            property.LastUpdatedOn = DateTime.Now;
            uow.PropertyRepository.Add(property);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("add/photo/{id}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int id) {
            
            var result = await photoService.UploadPhotoAsync(file);
            
            if(result != null && result.Error != null) 
                return BadRequest(result.Error.Message);

            var property = await uow.PropertyRepository.FindByIdAsync(id);
            var userId = GetUserId();
                
            var photo = new Photo();
            if(result!=null && result.SecureUrl!=null) {
                photo.ImageUrl = result.SecureUrl.AbsoluteUri;
                photo.PublicId = result.PublicId;
                photo.LastUpdatedBy = userId;
                photo.LastUpdatedOn = DateTime.Now;
            }

            if(property.Photos!=null && property.Photos.Count == 0) 
            {
                photo.IsPrimary = true;
            }

            if(property.Photos!=null) 
                property.Photos.Add(photo);

            await uow.SaveAsync();
            
            return StatusCode(201);
        }

        [HttpPost("add/local/photo/{id}")]
        [Authorize]
        public async Task<IActionResult> AddPropertyLocalPhoto(IFormFile file, int id) {
            
            var result = await localPhotoService.UploadPhotoAsync(file);

            if(result != null && result.Error != null) 
                return BadRequest(result.Error.Message);

            var property = await uow.PropertyRepository.FindByIdAsync(id);
            var userId = GetUserId();
                
            var photo = new Photo();
            if(result!=null && result.ImageUrl != string.Empty) {
                photo.ImageUrl = result.ImageUrl;
                photo.PublicId = result.PublicId;
                photo.LastUpdatedBy = userId;
                photo.LastUpdatedOn = DateTime.Now;
            }

            if(property.Photos!=null && property.Photos.Count == 0) 
            {
                photo.IsPrimary = true;
            }

            if(property.Photos!=null) 
                property.Photos.Add(photo);

            await uow.SaveAsync();
            
            return StatusCode(201);
        }

        [HttpPost("set-primary-photo/{id}/{publicId}")]
        [Authorize]
        public async Task<IActionResult> SetPrimaryPhoto(int id, string publicId) {
            var userId = GetUserId();

            var property = await uow.PropertyRepository.FindByIdAsync(id);

            if(property == null) 
                return BadRequest("No such property or photo exists");

            if(property.PostedBy != userId) 
                return BadRequest("Your are not authorised to change the photo");
            
            var photo = property.Photos.FirstOrDefault(p => p.PublicId == publicId);

            if(photo == null) 
                return BadRequest("No such property or photo exists");

            if(photo.IsPrimary) 
                return BadRequest("This is already a primary photo");

            var currentPrimary = property.Photos.FirstOrDefault(p => p.IsPrimary);
            if(currentPrimary!=null) currentPrimary.IsPrimary = false;
            photo.IsPrimary = true;

            if(await uow.SaveAsync()) return NoContent();

            return BadRequest("Some error has occured, failed to set primary photo");
        }

        [HttpDelete("delete-photo/{id}/{publicId}")]
        [Authorize]
        public async Task<IActionResult> DeletePhoto(int id, string publicId) {
            var userId = GetUserId();

            var property = await uow.PropertyRepository.FindByIdAsync(id);

            if(property == null) 
                return BadRequest("No such property or photo exists");

            if(property.PostedBy != userId) 
                return BadRequest("Your are not authorised to delete the photo");
            
            var photo = property.Photos.FirstOrDefault(p => p.PublicId == publicId);

            if(photo == null) 
                return BadRequest("No such property or photo exists");

            if(photo.IsPrimary) 
                return BadRequest("You can not delete primary photo");

            property.Photos.Remove(photo);

            if(await uow.SaveAsync()) return Ok();

            return BadRequest("Some error has occured, failed to delete photo");
        }
    }
}