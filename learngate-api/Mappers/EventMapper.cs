using learngate_api.DTOs.ClassDto;
using learngate_api.DTOs.EventDto;
using learngate_api.Models;

namespace learngate_api.Mappers
{
    public static class EventMapper
    {
        public static GetEventDto ToEventDto(this Event EventModel)
        {
            return new GetEventDto
            {
                Id = EventModel.Id,
                Title = EventModel.Title,
                Description = EventModel.Description,
                StartTime = EventModel.StartTime,
                EndTime = EventModel.EndTime,
                ClassId = EventModel.ClassId,
                Class = new GetClassNameDto
                {
                    Id = EventModel.Class.Id,
                    Name = EventModel.Class.Name,
                }
            };
        }

        public static Event ToEventModel(this CreateEventDto EventDto)
        {
            return new Event
            {
              
                Title = EventDto.Title,
                Description = EventDto.Description,
                StartTime = EventDto.StartTime,
                EndTime = EventDto.EndTime,
                ClassId = EventDto.ClassId
              
            };
        }
    }
}
       
