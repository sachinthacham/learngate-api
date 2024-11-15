using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IParentRepository
    {
        Task<List<Parent>> GetAllParentsAsync();
        Task<Parent?> GetParentByIdAsync(int Id);
        Task<Parent> CreateParentAsync(Parent parent);
        Task<Parent> UpdateParentAsync(Parent parent);
        Task<Parent> DeleteParentAsync(int id);
        Task<int> GetParentCountAsync();
    }
}
