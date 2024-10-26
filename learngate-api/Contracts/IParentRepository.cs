using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IParentRepository
    {
        Task<List<Parent>> GetAllParentsAsync();
    }
}
