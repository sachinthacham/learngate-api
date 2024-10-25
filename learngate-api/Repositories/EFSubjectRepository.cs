using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFSubjectRepository : ISubjectRepository
    {
        private readonly LearnGateDbContext _context;

        public EFSubjectRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _context.subjects.ToListAsync();
        }
    }
}
