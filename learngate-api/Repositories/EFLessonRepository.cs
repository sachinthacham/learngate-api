using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFLessonRepository: ILessonRepository
    {
        private readonly LearnGateDbContext _context;

        public EFLessonRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons
                .Include(x => x.Subject)
                .Include(x=> x.Class)
                .Include(x => x.Teacher)
                .ToListAsync();
        }

        public async Task<Lesson?> GetLessonByIdAsync(int Id)
        {
            return await _context.Lessons.FirstOrDefaultAsync();
        }

        public async Task<List<Lesson>> GetLessonByClassSubjectIdAsync(int ClassSubjectId)
        {
            return await _context.Lessons
                .Where(x => x.ClassSubjectId == ClassSubjectId)
                .Include(x => x.ClassSubject)
                .ToListAsync();
        }
        public async Task<Lesson> CreateLessonAsync(Lesson lesson)
        {
            var newLesson = new Lesson
            {
                Name = lesson.Name,
                Day = lesson.Day,
                StartTime = lesson.StartTime,
                EndTime = lesson.EndTime,
                SubjectId = lesson.SubjectId,
                ClassId = lesson.ClassId,
                TeacherId = lesson.TeacherId,
            };
            await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync();
            return newLesson;
        }
        public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();  
            return lesson;
        }

        public async Task<Lesson> DeleteLessonAsync(int id)
        {
            var lessonToDelete = await _context.Lessons.FirstOrDefaultAsync();
            if (lessonToDelete != null)
            {
                _context.Lessons.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
                return lessonToDelete;
            }
            return null;
        }
    }
}
