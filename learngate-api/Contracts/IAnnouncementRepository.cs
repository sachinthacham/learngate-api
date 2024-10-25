using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAllAnnouncementsAsync();
    }
}
