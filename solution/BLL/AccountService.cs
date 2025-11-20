using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAL;

namespace BLL
{
    public class AccountService : IAccountService
    {
        private IAccountRepo repo;
        public AccountService(IAccountRepo repo)
        {
            this.repo = repo;
        }
        public PantherAccount? Login(string email, string password)
        {
            return repo.GetPantherAccount(email, password);
        }
    }
}
