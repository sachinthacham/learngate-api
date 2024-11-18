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



        public async Task<Dictionary<string, int>> GetCurrentWeekAttendanceAsync()
        {
            // Calculate the start (Monday) and end (Friday) of the current week
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(4); // Friday

            // Query the attendance table
            var attendanceData = await _context.Attendances
                .Where(a => a.Date >= startOfWeek && a.Date <= endOfWeek) // Filter by date
                .GroupBy(a => a.Date.DayOfWeek) // Group by day of the week
                .Select(g => new
                {
                    DayOfWeek = g.Key,               // Grouped day (e.g., Monday = 1)
                    AttendanceCount = g.Count()      // Count of attendance entries
                })
                .ToListAsync();

            // Prepare results as a dictionary (DayName -> Count)
            var weekAttendance = new Dictionary<string, int>();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
            {
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Friday) // Only include weekdays
                {
                    var count = attendanceData
                        .Where(d => d.DayOfWeek == day)
                        .Select(d => d.AttendanceCount)
                        .FirstOrDefault();

                    weekAttendance.Add(day.ToString(), count);
                }
            }

            return weekAttendance;
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
