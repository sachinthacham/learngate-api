using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.DTOs.TeacherDto;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{   
    public class EFTeacherRepository: ITeacherRepository
    {
        private readonly LearnGateDbContext _context;
        public EFTeacherRepository( LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTeacherCountAsync()
        {
            var totalCount = await _context.Teachers.CountAsync();
            return totalCount;
         }
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers
                   .Include(teacher => teacher.TeacherSubjects) // Include the relationship table
                   .ThenInclude(teacherSubject => teacherSubject.Subject) // Then include the subjects
                   .ToListAsync();
               
        }
        public async Task<int> TotalStudentCountAsync()
        {
            var totalCount = await _context.Students.CountAsync();
            return totalCount;

        }
        public async Task<List<Teacher>> GetAllTeachersAsync(
            string? search,
            int? subjectId,
            int pageNumber = 1,
            int pageSize = 10)

        {
            var query = _context.Teachers
                .Include(teacher => teacher.TeacherSubjects)
                .ThenInclude(teacherSubject => teacherSubject.Subject)
                .AsQueryable();

            // Search by teacher name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    s.Name.Contains(search));
                    
            }

            // Filter by subjectId
            if (subjectId.HasValue)
            {
                query = query.Where(s => s.TeacherSubjects.Any(x => x.Subject.Id == subjectId.Value));
            }


            // Pagination
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetTotalCountAsyncForFilter(string? search, int? subjectId)
        {
            var query = _context.Teachers.AsQueryable();

            //search by teacher name
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    s.Name.Contains(search));

            }

            // Filter by subjectId
            if (subjectId.HasValue)
            {
                query = query.Where(s => s.TeacherSubjects.Any(x => x.Subject.Id == subjectId.Value));
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByTeacherIdAsync(int teacherId)
        {
            return await _context.TeacherSubjects
                .Where(ts => ts.TeacherId == teacherId)
                .Select(ts => ts.Subject)
                .ToListAsync();
        }
        public async Task<Teacher?> GetTeacherByIdAsync(int Id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher, List<int> subjectIds)
        {
            var newTeacher = new Teacher
            {
                UserName = teacher.UserName,
                Name = teacher.Name,
                Surname = teacher.Surname,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Address = teacher.Address,
                Img = teacher.Img,
                BloodType = teacher.BloodType,
                Sex = teacher.Sex,
                TeacherSubjects = new List<TeacherSubject>()
            };

            foreach (var subjectId in subjectIds)
            {
                var subject = await _context.Subjects.FindAsync(subjectId);
                if (subject != null)
                {
                    // Step 3: Add to the TeacherSubjects Navigation Property
                    newTeacher.TeacherSubjects.Add(new TeacherSubject
                    {
                        Teacher = newTeacher,
                        Subject = subject
                    });
                }
            }
            await _context.Teachers.AddAsync(newTeacher);
            await _context.SaveChangesAsync();
            return newTeacher;
        }
        public async Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeacherAsync(int id)
        {
            var teacherToDelete = await _context.Teachers.FirstOrDefaultAsync();
            if (teacherToDelete != null)
            {
                _context.Teachers.Remove(teacherToDelete);
                await _context.SaveChangesAsync();
                return teacherToDelete;
            }
            return null;
        }
    }
}
