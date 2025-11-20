
namespace PantherPetManagement.DAL.Repositories
{
    public interface IPantherAccountRepository
    {
        Task<PantherAccount> Login(string email, string password);
    }
}
