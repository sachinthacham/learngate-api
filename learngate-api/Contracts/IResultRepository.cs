using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IResultRepository
    {
        Task <List<Result>> GetAllResultsAsync ();
    }
}
