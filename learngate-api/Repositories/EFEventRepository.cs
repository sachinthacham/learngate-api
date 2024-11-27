using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFEventRepository: IEventRepository
    {      
        private readonly LearnGateDbContext _context;
        public EFEventRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _context.Events.Include(x => x.Class).ToListAsync();
        }

        public async Task<List<Event>> GetRecentEventsAsync()
        {
            return await _context.Events.OrderByDescending(x => x.StartTime).Take(5).Include(x => x.Class).ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int Id)
        {
            return await _context.Events.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            var eventnew = new Event
            {
                Title = newEvent.Title,
                Description = newEvent.Description,
                StartTime = newEvent.StartTime,
                EndTime = newEvent.EndTime,
                ClassId = newEvent.ClassId
            };
            await _context.Events.AddAsync(eventnew);
            await _context.SaveChangesAsync();
            return eventnew;

        }
        public async Task<Event> UpdateEventAsync(Event newclass)
        {
            _context.Events.Update(newclass);
            await _context.SaveChangesAsync();
            return newclass;
        }
        public async Task<Event> DeleteEventAsync(int id)
        {
            var eventToDelete = await _context.Events.FirstOrDefaultAsync();
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return eventToDelete;
            }
            return null;
        }
    }
}
