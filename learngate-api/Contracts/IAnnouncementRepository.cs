using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAllAnnouncementsAsync();
        Task<Announcement?> GetAnnouncementByIdAsync(int id);
        Task<Announcement> CreateAnnouncementAsync(Announcement newAnnouncement);
        Task<Announcement> UpdateAnnouncementAsync(Announcement newAnnouncement);
        Task <Announcement> DeleteAnnouncementAsync(int id);
        Task<List<Announcement>> GetRecentAnnouncementsAsync();
    }
}
