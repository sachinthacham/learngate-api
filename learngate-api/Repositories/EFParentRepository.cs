using learngate_api.Contracts;
using learngate_api.Data;
using learngate_api.Models;
using Microsoft.EntityFrameworkCore;

namespace learngate_api.Repositories
{
    public class EFParentRepository : IParentRepository
    {
        private readonly LearnGateDbContext _context;

        public EFParentRepository(LearnGateDbContext context)
        {
            _context = context;
        }

        

        public async Task<int> GetParentCountAsync()
        {
            var totalCount = await _context.Parents.CountAsync();
            return totalCount;
        }
        public async Task<List<Parent>> GetAllParentsAsync()
        {
            return await _context.Parents.Include(x => x.Students).ToListAsync();
        }
        
        public async Task<Parent?> GetParentByIdAsync(int Id)
        {
            return await _context.Parents.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            var newParent = new Parent
            {
                UserName = parent.UserName,
                Name = parent.Name,
                Surname = parent.Surname,
                Email = parent.Email,
                Phone = parent.Phone,
                Address = parent.Address,
            };
            await _context.Parents.AddAsync(newParent);
            await _context.SaveChangesAsync();
            return newParent;
        }
        public async Task<Parent> UpdateParentAsync(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
            return parent;
        }

        public async Task<Parent> DeleteParentAsync(int id)
        {
            var parentToDelete = await _context.Parents.FirstOrDefaultAsync();
            if (parentToDelete != null)
            {
                _context.Parents.Remove(parentToDelete);
                await _context.SaveChangesAsync();
                return parentToDelete;
            }
            return null;
        }
    }
}
