using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFStudentRepository: IStudentRepository
    {
        private readonly LearnGateDbContext _context;
        public EFStudentRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<int> TotalStudentCountAsync()
        {
            var totalCount = await _context.Students.CountAsync();
            return totalCount;
            
        }
        public async Task<int> TotalBoyCountAsync()
        {
            var totalBoyCount = await _context.Students.Where(x => x.Sex == UserSex.Male).CountAsync();
            return totalBoyCount;

        }
        public async Task<int> TotalGirlCountAsync()
        {
            var totalGirlCount = await _context.Students.Where(x => x.Sex == UserSex.Female).CountAsync();
            return totalGirlCount;

        }


        public async Task<List<Student>> GetAllStudentsAsync(
            string? search,
            int? classId,
            int? gradeId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var query = _context.Students
                .Include(x => x.Parent)
                .Include(x => x.Class)
                .Include(x => x.Grade)
                .AsQueryable();

            // Search by student name or parent's name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    s.Name.Contains(search) ||
                    s.Parent.Name.Contains(search) ||
                    s.Parent.Surname.Contains(search));
            }

            // Filter by ClassId
            if (classId.HasValue)
            {
                query = query.Where(s => s.Class.Id == classId.Value);
            }

            // Filter by GradeId
            if (gradeId.HasValue)
            {
                query = query.Where(s => s.Grade.Id == gradeId.Value);
            }

            // Pagination
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetTotalCountAsyncForFilter(string? search, int? classId, int? gradeId)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    s.Name.Contains(search) ||
                    s.Parent.Name.Contains(search));
            }

            if (classId.HasValue)
            {
                query = query.Where(s => s.Class.Id == classId.Value);
            }

            if (gradeId.HasValue)
            {
                query = query.Where(s => s.Grade.Id == gradeId.Value);
            }

            return await query.CountAsync();
        }



        public async Task<Student?> GetStudentByIdAsync(string username)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.UserName == username);
        }
        public async Task<Student> CreateStudentAsync(Student student)
        {
           
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();  
            return student;
        }
        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteStudentAsync(int id)
        {
            var studentToDelete = await _context.Students.FirstOrDefaultAsync();
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
                return studentToDelete;
            }
            return null;
        }
    }
}
