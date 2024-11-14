using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFGradeRepository: IGradeRepository
    {
        private readonly LearnGateDbContext _context;
        public EFGradeRepository( LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> GetAllGradesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade?> GetGradeByIdAsync(int Id)
        {
            return await _context.Grades.FirstOrDefaultAsync();
        }
        public async Task<Grade> CreateGradeAsync(Grade grade)
        {
            var newGrade = new Grade
            {
                Level = grade.Level,
            };
            await _context.Grades.AddAsync(newGrade);
            await _context.SaveChangesAsync();
            return newGrade;
        }
        public async Task<Grade> UpdateGradeAsync(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> DeleteGradeAsync(int id)
        {
            var gradeToDelete = await _context.Grades.FirstOrDefaultAsync();
            if (gradeToDelete != null)
            {
                _context.Grades.Remove(gradeToDelete);
                await _context.SaveChangesAsync();
                return gradeToDelete;
            }
            return null;
        }
    }
}
