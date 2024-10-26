using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClasses();
    }
}
