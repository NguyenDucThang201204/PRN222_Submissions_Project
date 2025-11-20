using PantherPetManagement.DAL;


namespace PantherPetManagement.BLL.Services
{
    public interface IPantherAccountService
    {
        Task<PantherAccount> Login(string email, string password);
    }
}
