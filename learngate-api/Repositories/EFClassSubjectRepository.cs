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
                .Include(x => x.Subject)
                .Include(x => x.Class)
                .Include(x => x.Teacher)
                .Where(x => x.ClassId == ClassId)
                .ToListAsync();

        }

        public async Task<ClassSubject?> GetClassSubjectById(int classSubjectId)
        {
            return await _context.ClassSubjects.Include(x => x.Subject)
                .Include(x => x.Class)
                .Include(x => x.Teacher)
                .FirstOrDefaultAsync(x => x.ClassSubjectId == classSubjectId);
        }

        public async Task<ClassSubject> CreateClassSubject(ClassSubject classSubject)
        {
            // Create the new class entity
            var ClassSubjectNew = new ClassSubject
            {
               
                SubjectId = classSubject.SubjectId,
                TeacherId = classSubject.TeacherId,
                ClassId = classSubject.ClassId,
            };

            // Add and save the new class
            await _context.ClassSubjects.AddAsync(ClassSubjectNew);
            await _context.SaveChangesAsync();

            // Reload the created class with navigation properties
            var createdClass = await _context.ClassSubjects
                .Include(c => c.Teacher)       // Load the Grade navigation property
                .Include(c => c.Subject) // Load the Supervisor navigation property
                .Include(c => c.Class)
                .FirstOrDefaultAsync(c => c.ClassSubjectId == ClassSubjectNew.ClassSubjectId);

            return ClassSubjectNew;
        }

    }
}
