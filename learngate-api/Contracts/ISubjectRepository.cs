using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject?> GetSubjectByIdAsync(int Id);
        Task<Subject> CreateSubjectAsync(Subject subject, List<int> teacherIds);
        
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task<Subject> DeleteSubjectAsync(int Id);

        Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(int subjectId);

        Task <List<Subject>> GetAllSubjectNames();
    }
}
