using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFAssignmentRepository: IAssingmentRepository
    {
        private readonly LearnGateDbContext _context;

        public EFAssignmentRepository(LearnGateDbContext context)
        {
            _context = context;
            
        }
        public async Task <List<Assignment>> GetAllAssignmentAsync()
        {
            return await _context.Assignments.ToListAsync();
        }
    }
}
