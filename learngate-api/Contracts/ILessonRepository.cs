using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllLessonsAsync();
      
        Task<Lesson?> GetLessonByIdAsync(int Id);
        Task<Lesson> CreateLessonAsync(Lesson lesson);
        Task<Lesson> UpdateLessonAsync(Lesson lesson);
        Task<Lesson> DeleteLessonAsync(int id);
    }
}
