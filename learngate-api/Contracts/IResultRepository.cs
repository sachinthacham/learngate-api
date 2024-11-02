using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IResultRepository
    {
        Task <List<Result>> GetAllResultsAsync ();
     
        Task<Result?> GetResultByIdAsync(int Id);
        Task<Result> CreateResultAsync(Result result);
        Task<Result> UpdateResultAsync(Result result);
        Task<Result> DeleteResultAsync(int Id);
    }
}
