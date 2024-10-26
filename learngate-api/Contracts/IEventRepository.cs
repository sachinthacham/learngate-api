using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEventsAsync();
    }
}
