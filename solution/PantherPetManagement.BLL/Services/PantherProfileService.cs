using PantherPetManagement.DAL;
using PantherPetManagement.DAL.Repositories;


namespace PantherPetManagement.BLL.Services
{
    public class PantherProfileService : IPantherProfileService
    {
        private readonly IPantherProfileRepository _repo;
        public PantherProfileService(IPantherProfileRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<PantherProfile>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public async Task<PantherProfile> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<PantherProfile>> GetAllByOr(double? search1, string search2)
        {
            return await _repo.GetAllByOr(search1, search2);
        }
        public Task AddAsync(PantherProfile add)
        {
            return _repo.AddAsync(add);
        }
        public Task DeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }
        public Task UpdateASync(PantherProfile update)
        {
            return _repo.UpdateASync(update);
        }

    }
}
