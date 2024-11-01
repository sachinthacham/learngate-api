using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClassesAsync();
        Task<Class?> GetClassByIdAsync(int Id);
        Task<Class> CreateClassAsync(Class newclass);
        Task<Class> UpdateClassAsync(Class newclass);
        Task<Class> DeleteClassAsync(int id);
    }
}
