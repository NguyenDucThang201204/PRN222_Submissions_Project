using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService
    {
        private readonly AccountRepo _loginRepo;

        public AccountService(AccountRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        public PantherAccount LoginAccount(string email, string password)
        => _loginRepo.LoginAccount(email, password);
    }
}
