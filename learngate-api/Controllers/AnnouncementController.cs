using learngate_api.Contracts;
using learngate_api.Mappers;
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
    }
}
