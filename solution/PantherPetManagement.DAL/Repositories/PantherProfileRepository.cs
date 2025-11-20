using Microsoft.EntityFrameworkCore;


namespace PantherPetManagement.DAL.Repositories
{
    public class PantherProfileRepository : IPantherProfileRepository
    {
        private readonly Su25pantherDbContext _context;
        public PantherProfileRepository(Su25pantherDbContext context)
        {
            _context = context;
        }

        public async Task<PantherProfile> GetByIdAsync(int id)
        {
            return await _context.PantherProfiles
                .Include(p => p.PantherType)
                .FirstOrDefaultAsync(p => p.PantherProfileId == id);
        }
        public async Task AddAsync(PantherProfile add)
        {
            await _context.PantherProfiles.AddAsync(add);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var Delete = await _context.PantherProfiles.FindAsync(id);
            _context.PantherProfiles.Remove(Delete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateASync(PantherProfile update)
        {
            _context.PantherProfiles.Update(update);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PantherProfile>> GetAllAsync()
        {
            return await _context.PantherProfiles
                .Include(p => p.PantherType)
                .OrderByDescending(p => p.PantherProfileId)
                .ToListAsync();
        }
        public async Task<List<PantherProfile>> GetAllByOr(double? search1, string search2)
        {
            //có 1 trong 2
            if (search1 != null || !string.IsNullOrEmpty(search2))
            {
                return await _context.PantherProfiles
                    .Include(p => p.PantherType)
                    .OrderByDescending(p => p.PantherProfileId)
                    .Where(p => p.Weight == search1 || p.PantherType.PantherTypeName.Contains(search2))
                    .ToListAsync();
            }
            //ko có cả 2
            return await GetAllAsync();
        }
    }
}
