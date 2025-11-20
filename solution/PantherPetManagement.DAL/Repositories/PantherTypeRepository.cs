using Microsoft.EntityFrameworkCore;


namespace PantherPetManagement.DAL.Repositories
{
    public class PantherTypeRepository : IPantherTypeRepository
    {
        private readonly Su25pantherDbContext _context;
        public PantherTypeRepository(Su25pantherDbContext context)
        {
            _context = context;
        }
        public async Task<List<PantherType>> GetAllAsync()
        {
            return await _context.PantherTypes.ToListAsync();
        }
    }
}
