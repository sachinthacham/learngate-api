using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllExamsAsync();
    }
}
