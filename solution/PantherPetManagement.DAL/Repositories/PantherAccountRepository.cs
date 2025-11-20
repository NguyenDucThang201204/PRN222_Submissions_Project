using Microsoft.EntityFrameworkCore;


namespace PantherPetManagement.DAL.Repositories
{
    public class PantherAccountRepository : IPantherAccountRepository
    {
        private readonly Su25pantherDbContext _context;
        public PantherAccountRepository(Su25pantherDbContext context)
        {
            _context = context;
        }

        public async Task<PantherAccount> Login(string email, string password)
        {
           return await _context.PantherAccounts.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
