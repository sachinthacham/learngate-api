using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAssignmentRepository
    {
        Task <List<Assignment>> GetAllAssignmentAsync();
    }
}
