using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/announcement")]
    [ApiController]

    
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementController(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllAnnouncements()
        {
            try
            {
                var allAnnouncements = await _announcementRepository.GetAllAnnouncementsAsync();
                var AnnouncementDto = allAnnouncements.Select(s => s.ToAnnouncementDto());
                return Ok(AnnouncementDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetAnnouncementById(int Id)
        {
            try
            {
                var announcement = await _announcementRepository.GetAnnouncementByIdAsync(Id);
                return Ok(announcement);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto announcementDto)
        {
            try
            {
                var newAnnouncement = await _announcementRepository.CreateAnnouncementAsync(announcementDto.ToAnnouncementModel());
                var newAnnouncementDto = newAnnouncement.ToAnnouncementDto();
                return CreatedAtAction(nameof(GetAnnouncementById), new { id = newAnnouncement.Id }, newAnnouncementDto);

               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAnnouncement([FromRoute] int Id, [FromBody] UpdateAnnouncementDto updateDto)
        {
            try
            {
                var excistingModel = await _announcementRepository.GetAnnouncementByIdAsync(Id);
                if(excistingModel == null)
                {
                    return NotFound("There are no Announcement found");
                }
                excistingModel.Title = updateDto.Title;
                excistingModel.Description = updateDto.Description;
                excistingModel.ClassId = updateDto.ClassId;

                await _announcementRepository.UpdateAnnouncementAsync(excistingModel);
                var announcementDto = excistingModel.ToAnnouncementDto();
                return Ok(announcementDto);
                
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]

        public async Task<IActionResult> DeleteAnnouncement([FromRoute] int Id)
        {
            try
            {
               
                var deletedAnnouncement = await _announcementRepository.DeleteAnnouncementAsync(Id);
                var deletedAnnouncementDto = deletedAnnouncement.ToAnnouncementDto();
                return Ok(deletedAnnouncementDto);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
