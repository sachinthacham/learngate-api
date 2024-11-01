using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetAllGradesAsync();
        Task<Grade?> GetGradeByIdAsync(int Id);
        Task<Grade> CreateGradeAsync(Grade grade);
        Task<Grade> UpdateGradeAsync(Grade grade);
        Task<Grade> DeleteGradeAsync(int Id);
    }
}
