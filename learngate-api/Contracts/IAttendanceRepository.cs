using learngate_api.Models;

namespace learngate_api.Contracts
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAttendanceAsync();
        Task<Attendance?> GetAttendanceByIdAsync(int Id);
        Task<Attendance> CreateAttendanceAsync(Attendance attendance);
        Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
        Task <Attendance> DeleteAttendanceAsync(int Id);

    }
}
