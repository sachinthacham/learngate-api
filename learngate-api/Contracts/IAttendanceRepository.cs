using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAttendanceAsync();
    }
}
