using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFAnnouncementRepository : IAnnouncementRepository
    {
        private readonly LearnGateDbContext _context;
        public EFAnnouncementRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Announcement>> GetAllAnnouncementsAsync()
        {
            return await _context.Announcements.Include(c => c.Class).ToListAsync();
        }

        public async Task<List<Announcement>> GetRecentAnnouncementsAsync()
        {
            return await _context.Announcements.OrderByDescending(x => x.Date).Take(5).Include(c => c.Class).ToListAsync();
        }



        public async Task<Announcement?> GetAnnouncementByIdAsync(int Id)
        {
            return await _context.Announcements.Include(c => c.Class).FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Announcement> CreateAnnouncementAsync(Announcement announcement)
        {
            var newAnnouncement = new Announcement
            {
                Title = announcement.Title,
                Description = announcement.Description,
                ClassId = announcement.ClassId
            };
            await _context.Announcements.AddAsync(newAnnouncement);
            await _context.SaveChangesAsync();
            return newAnnouncement;
        }
        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
            await _context.SaveChangesAsync();
            return announcement;
        }

        public async Task<Announcement> DeleteAnnouncementAsync(int Id)
        {
            var announcementToDelete = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == Id);
            if (announcementToDelete != null)
            {
                _context.Announcements.Remove(announcementToDelete);
                await _context.SaveChangesAsync();
                return announcementToDelete;
            }

            return null;
        }

    }
}
