using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachersAsync();
    }
}
