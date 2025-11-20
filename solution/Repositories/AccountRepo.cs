using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public  class AccountRepo
    {
        public PantherAccount LoginAccount(string Email, string password)
        {
            using (var context = new SU25PantherDBContext())
            {
                var account = context.PantherAccounts
                    .FirstOrDefault(a => a.Email == Email && a.Password == password);

                if (account != null)
                {
                    return account;
                }
                return null;
            }
        }
    }
}
