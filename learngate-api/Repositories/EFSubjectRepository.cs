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
            return await _context.Subjects
                .Include(x => x.TeacherSubjects)
                .ThenInclude(x => x.Teacher)
                .Include(x => x.Lessons).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(int subjectId)
        {
            return await _context.TeacherSubjects
                .Where(ts => ts.SubjectId == subjectId)
                .Select(ts => ts.Teacher)
                .ToListAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(int Id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Subject>> GetAllSubjectNames()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject, List<int> teacherIds)
        {
            var newSubject = new Subject {
                Name = subject.Name,
                TeacherSubjects = new List<TeacherSubject>()
            };
            foreach (var TeacherId in teacherIds)
            {
                var teacher = await _context.Teachers.FindAsync(TeacherId);
                if (teacher != null)
                {
                    // Step 3: Add to the TeacherSubjects Navigation Property
                    newSubject.TeacherSubjects.Add(new TeacherSubject
                    {
                        Teacher = teacher,
                        Subject = newSubject
                    });
                }
            }
            await _context.Subjects.AddAsync(newSubject);
            await _context.SaveChangesAsync();
            return newSubject;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> DeleteSubjectAsync(int id)
        {
            var subjectToDelete = await _context.Subjects.FirstOrDefaultAsync();
            if (subjectToDelete != null)
            {
                _context.Subjects.Remove(subjectToDelete);
                await _context.SaveChangesAsync();
                return subjectToDelete;
            }
            return null;
        }

    }
}
