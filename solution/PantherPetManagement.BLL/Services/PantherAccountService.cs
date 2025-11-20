using PantherPetManagement.DAL;
using PantherPetManagement.DAL.Repositories;


namespace PantherPetManagement.BLL.Services
{
    public class PantherAccountService : IPantherAccountService
    {
        private readonly IPantherAccountRepository _repo;
        public PantherAccountService(IPantherAccountRepository repo)
        {
            _repo = repo;
        }
        public async Task<PantherAccount> Login(string email, string password)
        {
            return await _repo.Login(email, password);
        }

    }
}
