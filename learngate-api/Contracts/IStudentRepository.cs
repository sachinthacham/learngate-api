using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}
