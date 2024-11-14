using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFAttendanceRepository: IAttendanceRepository
    {
        private readonly LearnGateDbContext _context;

        public EFAttendanceRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAllAttendanceAsync()
        {
            return await _context.Attendances.Include(x => x.Lesson).Include(x => x.Student).ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int Id)
        {
            return await _context.Attendances.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
        {
            var newAttendance = new Attendance
            {
                Date = attendance.Date,
                Present = attendance.Present,
                StudentId = attendance.StudentId,
                LessonId = attendance.LessonId,
            };
            await _context.Attendances.AddAsync(newAttendance);
            await _context.SaveChangesAsync();
            return newAttendance;
        }
        public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> DeleteAttendanceAsync(int Id)
        {
            var attendanceToDelete = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == Id);
            if (attendanceToDelete != null)
            {
                _context.Attendances.Remove(attendanceToDelete);
                await _context.SaveChangesAsync();
                return attendanceToDelete;
            }

            return null;
        }
    }
}
