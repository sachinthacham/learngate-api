using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFResultRepository:IResultRepository
    {
        private readonly LearnGateDbContext _context;

        public EFResultRepository(LearnGateDbContext context)
        {
            _context = context;
        }
        public async Task<List<Result>> GetAllResultsAsync()
        {
            return await _context.Results
                .Include(x => x.Exam)
                .Include(x => x.Class)
                .Include(x => x.Student)
                .Include(x => x.Subject).ToListAsync();
        }

        public async Task<Result?> GetResultByIdAsync(int Id)
        {
            return await _context.Results
                .Include(x => x.Exam)
               
                .Include(x => x.Student)
                .FirstOrDefaultAsync();
        }
        public async Task<Result> CreateResultAsync(Result result)
        {
            var newResult = new Result
            {
                Score = result.Score,
                ExamId = result.ExamId,
                //AssignmentId = resultDto.AssignmentId,
                StudentId = result.StudentId,
            };
            await _context.Results.AddAsync(newResult);
            await _context.SaveChangesAsync();
            return newResult;
        }
        public async Task<Result> UpdateResultAsync(Result result)
        {
            _context.Results.Update(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Result> DeleteResultAsync(int id)
        {
            var resultToDelete = await _context.Results.FirstOrDefaultAsync();
            if (resultToDelete != null)
            {
                _context.Results.Remove(resultToDelete);
                await _context.SaveChangesAsync();
                return resultToDelete;
            }
            return null;
        }
    }
}
