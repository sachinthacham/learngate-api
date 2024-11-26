using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachersAsync(
          string? search,
          int? subjectId,
          int pageNumber = 1,
          int pageSize = 10);
        Task<Teacher?> GetTeacherByIdAsync(string username);
        Task<Teacher> CreateTeacherAsync(Teacher teacher,List<int> subjectIds);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        Task <Teacher> DeleteTeacherAsync(int Id);
        Task<IEnumerable<Subject>> GetSubjectsByTeacherIdAsync(int teacherId);
        Task<int> GetTeacherCountAsync();
        Task<int> GetTotalCountAsyncForFilter(string? search, int? subjectId);
    }
}
