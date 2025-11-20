using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAL
{
    public class AccountRepo : IAccountRepo
    {
        public PantherAccount? GetPantherAccount(string email, string password)
        {
            var _context = new Su25pantherDbContext();
            return _context.PantherAccounts
                .FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
