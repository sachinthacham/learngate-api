using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFClassSubjectRepository:IClassSubjectRepository
    {
        private readonly LearnGateDbContext _context;
        
        public EFClassSubjectRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassSubject>> GetSubjectsByClassIdAsync(int ClassId)
        {
            return await _context.ClassSubjects
                .Where(x => x.ClassId == ClassId)
                .ToListAsync();

        }

    }
}
