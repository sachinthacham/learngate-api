using learngate_api.Contracts;
using learngate_api.DTOs.AnnouncementDto;
using learngate_api.DTOs.EventDto;
using learngate_api.Mappers;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [Route("getAll")]

        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var allEvents = await _eventRepository.GetAllEventsAsync();
                var eventDto = allEvents.Select(s => s.ToEventDto());
                return Ok(eventDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRecent")]
        public async Task<IActionResult> GetRecentEventsAsync()
        {
            try
            {
                var allEvents = await _eventRepository.GetRecentEventsAsync();
                var eventDto = allEvents.Select(s => s.ToEventDto());
                return Ok(eventDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getby/{Id}")]

        public async Task<IActionResult> GetEventById(int Id)
        {
            try
            {
                var getEvent = await _eventRepository.GetEventByIdAsync(Id);
                return Ok(getEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto eventDto)
        {
            try
            {
                var newEvent = await _eventRepository.CreateEventAsync(eventDto.ToEventModel());
                var newEventDto = newEvent.ToEventDto();
                return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEventDto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{Id}")]

        public async Task<IActionResult> UpdateAnnouncement([FromRoute] int Id, [FromBody] UpdateEventDto updateDto)
        {
            try
            {
                var excistingModel = await _eventRepository.GetEventByIdAsync(Id);
                if (excistingModel == null)
                {
                    return NotFound("There are no Events found");
                }
                excistingModel.Title = updateDto.Title;
                excistingModel.Description = updateDto.Description;
                excistingModel.StartTime = updateDto.StartTime;
                excistingModel.EndTime = updateDto.EndTime;
                excistingModel.ClassId = updateDto.ClassId;

                await _eventRepository.UpdateEventAsync(excistingModel);
                var eventDto = excistingModel.ToEventDto();
                return Ok(eventDto);

            }
            catch (Exception ex)
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

                var deletedEvent = await _eventRepository.DeleteEventAsync(Id);
                var deletedEventDto = deletedEvent.ToEventDto();
                return Ok(deletedEventDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
