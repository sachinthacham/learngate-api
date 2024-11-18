using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;
//using System.Runtime.InteropServices;

namespace learngate_api.Repositories
{
    public class EFClassRepository:IClassRepository
    {
        private readonly LearnGateDbContext _context;

        public EFClassRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.Include(x => x.Grade).Include(a => a.Supervisor).ToListAsync();
        }

        public async Task<List<Class>> GetClassesByGradeIdAsync(int gradeId)
        {
            return await _context.Classes
                .Where(x => x.GradeId == gradeId)
                .Include(x => x.Grade)
                .Include(a => a.Supervisor)
                .ToListAsync();
        }
        public async Task<Class?> GetClassByIdAsync(int Id)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Class> CreateClassAsync(Class newclass)
        {
            var ClassNew = new Class
            {
                Name = newclass.Name,
                Capacity = newclass.Capacity,
                SupervisorId = newclass.SupervisorId,
                GradeId = newclass.GradeId,
            };
            await _context.Classes.AddAsync(ClassNew);
            await _context.SaveChangesAsync();
            return ClassNew;
        }
        public async Task<Class> UpdateClassAsync(Class newclass)
        {
            _context.Classes.Update(newclass);
            await _context.SaveChangesAsync();
            return newclass;
        }

        public async Task<Class> DeleteClassAsync(int id)
        {
            var classToDelete = await _context.Classes.FirstOrDefaultAsync();
            if (classToDelete != null)
            {
                _context.Classes.Remove(classToDelete);
                await _context.SaveChangesAsync();
                return classToDelete;
            }
            return null;
        }
    }

}
