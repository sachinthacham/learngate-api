using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFAnnouncementRepository:IAnnouncementRepository
    {
        private readonly LearnGateDbContext _context;
        public EFAnnouncementRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

    }
}
