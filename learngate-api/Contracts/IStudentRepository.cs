using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int Id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task <Student> DeleteStudentAsync(int Id);
    }
}
