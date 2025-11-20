

namespace PantherPetManagement.DAL.Repositories
{
    public interface IPantherProfileRepository
    {
        Task<List<PantherProfile>> GetAllAsync();
        Task<List<PantherProfile>> GetAllByOr(double? search1, string search2);
        Task AddAsync(PantherProfile add);
        Task DeleteAsync(int id);
        Task UpdateASync(PantherProfile update);
        Task<PantherProfile> GetByIdAsync(int id);
    }
}
