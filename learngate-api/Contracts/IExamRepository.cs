using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllExamsAsync();
        Task<Exam?> GetExamByIdAsync(int Id);
        Task<Exam> CreateExamAsync(Exam exam);
        Task<Exam> UpdateExamAsync(Exam exam);
        Task<Exam> DeleteExamAsync(int Id);
    }
}
