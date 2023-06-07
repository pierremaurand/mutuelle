using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.SignalR;
using mefApi.HubConfig;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;

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
                return NotFound();
            }
            var membresDto = mapper.Map<IEnumerable<MembreDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound();
            }
            var membreDto = mapper.Map<MembreDto>(membre);
            return Ok(membreDto);
        }

        [HttpGet("get/infos/{id}")]
        public async Task<IActionResult> GetInfos(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound();
            }
            var membreDto = mapper.Map<MembreListDto>(membre);
            return Ok(membreDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(MembreDto membreDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var membre = mapper.Map<Membre>(membreDto);

            membre.ModifiePar = GetUserId();
            membre.ModifieLe = DateTime.Now;
            uow.MembreRepository.Add(membre);

            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("LoadInfos");
            return Ok(membre.Id);
        }

        [HttpPost("import")] 
        public async Task<IActionResult> Import(IEnumerable<MembreDto> membresDto) {
            var membres = mapper.Map<IEnumerable<Membre>>(membresDto);

            foreach (var membre in membres)
            {
                
                membre.ModifiePar = GetUserId();
                membre.ModifieLe = DateTime.Now;
                uow.MembreRepository.Add(membre);
            }

            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("LoadInfos");
            return StatusCode(201);
        }

        [HttpPost("addImage")]
        public async Task<IActionResult> AddImage(UploadImage imageDetails)
        {   
            if(imageDetails.MembreId == 0){
                return BadRequest("Update not allowed");
            } 
        
            var membreFromDb = await uow.MembreRepository.FindByIdAsync(imageDetails.MembreId);
            
            if(membreFromDb == null) 
                return BadRequest("Update not allowed");

            if(imageDetails.Image is null) {
                return BadRequest("Update not allowed");
            }

            byte[] bytes = Convert.FromBase64String(imageDetails.Image);
            
            Image image; 
            using(MemoryStream ms = new MemoryStream(bytes)){
                image = Image.FromStream(ms);
            }
            int i = 0;
            var imageName = "membre_"+imageDetails.MembreId+"_"+i+"."+imageDetails.Type;
            while(membreFromDb.Photo.Equals(imageName)){
                i += 1;
                imageName = "membre_"+imageDetails.MembreId+"_"+i+"."+imageDetails.Type;
            }

            image.Save("wwwroot/assets/images/"+imageName, ImageFormat.Png);

            membreFromDb.Photo = imageName;
            await uow.SaveAsync();

            return Ok();
        }

        [HttpPut("update/{id}")]
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
            await signalrHub.Clients.All.SendAsync("LoadInfos");
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMembre(int id)
        {
            uow.MembreRepository.Delete(id);
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("LoadInfos");
            return Ok(id);
        }

    }
}