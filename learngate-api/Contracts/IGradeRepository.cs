using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetAllGradesAsync();
    }
}
