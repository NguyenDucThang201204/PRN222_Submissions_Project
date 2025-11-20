

namespace PantherPetManagement.DAL.Repositories
{
    public interface IPantherTypeRepository
    {
        Task<List<PantherType>> GetAllAsync();

    }
}
