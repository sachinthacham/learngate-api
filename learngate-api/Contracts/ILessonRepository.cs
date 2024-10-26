using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllLessonsAsync();
    }
}
