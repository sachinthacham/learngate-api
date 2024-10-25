using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAssingmentRepository
    {
        Task <List<Assignment>> GetAllAssignmentAsync();
    }
}
