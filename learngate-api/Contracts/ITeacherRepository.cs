using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher?> GetTeacherByIdAsync(int Id);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        Task <Teacher> DeleteTeacherAsync(int Id);
        Task<IEnumerable<Subject>> GetSubjectsByTeacherIdAsync(int teacherId);
    }
}
