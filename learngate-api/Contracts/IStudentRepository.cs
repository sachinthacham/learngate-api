using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync(string? search,
            int? classId,
            int? gradeId,
            int pageNumber = 1,
            int pageSize = 10);
        Task<Student?> GetStudentByIdAsync(string username);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task <Student> DeleteStudentAsync(int Id);
        Task<int> TotalStudentCountAsync();
        Task<int> GetTotalCountAsyncForFilter(string? search, int? classId, int? gradeId);
        
        Task<int> TotalBoyCountAsync();
        Task<int> TotalGirlCountAsync();
        Task<List<Student>> GetStudentName();


    }
}
