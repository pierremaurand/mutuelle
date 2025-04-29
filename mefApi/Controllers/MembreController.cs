using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.SignalR;
using mefApi.HubConfig;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Versioning;

namespace mefApi.Controllers
{
    public class MembreController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IHubContext<SignalrServer> signalrHub; 

        public MembreController(IMapper mapper, IUnitOfWork uow, IHubContext<SignalrServer> signalrHub)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.signalrHub = signalrHub;
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAll()
        {
            var membres = await uow.MembreRepository.GetAllAsync();
            if(membres is null) {
                return NotFound("Aucun membre n'existe dans la bdd");
            }
            var membresDto = mapper.Map<List<MembreDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("membre/{id}")]
        public async Task<IActionResult> GetMembre(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound();
            }
            var membreDto = mapper.Map<MembreDto>(membre);
            return Ok(membreDto);
        }


        [HttpPost("membre")]
        public async Task<IActionResult> Add(MembreDto membreDto)
        {
            var membre = mapper.Map<Membre>(membreDto);

            var membreExist = await uow.MembreRepository.MembreExists(membreDto);

            if(membreExist){
                return BadRequest("Ce membre existe déjà dans la base");
            } 

            membre.ModifiePar = GetUserId();
            membre.ModifieLe = DateTime.Now;
            uow.MembreRepository.Add(membre);
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("MembreAdded", mapper.Map<MembreDto>(membre));
            return StatusCode(201);
        }

        [SupportedOSPlatform("windows")]
        [HttpPost("image")]
        public async Task<IActionResult> AddImage(UploadImage imageDetails)
        {
            if (imageDetails.MembreId == 0)
            {
                return BadRequest("Update not allowed");
            }

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(imageDetails.MembreId);

            if (membreFromDb == null)
                return BadRequest("Update not allowed");

            if (imageDetails.Image is null)
            {
                return BadRequest("Update not allowed");
            }

            byte[] bytes = Convert.FromBase64String(imageDetails.Image);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            int i = 0;
            var imageName = "membre_" + imageDetails.MembreId + "_" + i + "." + imageDetails.Type;

            // Fix: Ensure membreFromDb.Photo is not null before calling Equals
            while (!string.IsNullOrEmpty(membreFromDb.Photo) && membreFromDb.Photo.Equals(imageName))
            {
                i += 1;
                imageName = "membre_" + imageDetails.MembreId + "_" + i + "." + imageDetails.Type;
            }

            image.Save("wwwroot/assets/images/" + imageName, ImageFormat.Png);

            membreFromDb.Photo = imageName;
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("MembreAdded", mapper.Map<MembreDto>(membreFromDb));
            return StatusCode(201);
        }

        [HttpPut("membre/{id}")]
        public async Task<IActionResult> Update(int id,MembreDto membreDto)
        {
            if(id != membreDto.Id) 
                return BadRequest("Update not allowed");

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            
            if(membreFromDb == null) 
                return BadRequest("Update not allowed");

            membreFromDb.ModifiePar = GetUserId();
            membreFromDb.ModifieLe = DateTime.Now;
            mapper.Map(membreDto, membreFromDb);
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("MembreAdded", mapper.Map<MembreDto>(membreFromDb));
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMembre(int id)
        {
            //Faire quelques vérification avant de supprimer
            uow.MembreRepository.Delete(id);
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("MembreDeleted", id);
            return Ok(id);
        }

    }
}