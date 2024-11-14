using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFExamRepository:IExamRepository
    {
        private readonly LearnGateDbContext _context;

        public EFExamRepository(LearnGateDbContext context){ 

            _context = context;
        }

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _context.Exams.Include(x => x.Lesson).Include(x => x.Subject).Include(x => x.Class).ToListAsync();
        }

        public async Task<Exam?> GetExamByIdAsync(int Id)
        {
            return await _context.Exams.FirstOrDefaultAsync(x => x.Id == Id);

        }
        public async Task<Exam> CreateExamAsync(Exam exam)
        {
            var newExam = new Exam
            {
                Title = exam.Title,
                StartTime = exam.StartTime,
                EndTime = exam.EndTime,
                LessonID = exam.LessonID,
            };
            await _context.Exams.AddAsync(newExam);
            await _context.SaveChangesAsync();
            return newExam;
        }
        public async Task<Exam> UpdateExamAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> DeleteExamAsync(int id)
        {
            var examToDelete = await _context.Exams.FirstOrDefaultAsync();
            if (examToDelete != null)
            {
                _context.Exams.Remove(examToDelete);
                await _context.SaveChangesAsync();
                return examToDelete;
            }
            return null;
        }


    }
}
