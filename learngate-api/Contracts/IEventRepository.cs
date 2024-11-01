using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int Id);
        Task<Event> CreateEventAsync(Event newclass);
        Task<Event> UpdateEventAsync(Event newclass);
        Task<Event> DeleteEventAsync(int id);

    }
}
