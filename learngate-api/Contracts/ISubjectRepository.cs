using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface ISubjectRepository
    {
        Task <List<Subject>> GetAllSubjectsAsync ();
    }
}
