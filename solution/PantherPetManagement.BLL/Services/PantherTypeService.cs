using PantherPetManagement.DAL;
using PantherPetManagement.DAL.Repositories;


namespace PantherPetManagement.BLL.Services
{
    public class PantherTypeService : IPantherTypeService
    {
        private readonly IPantherTypeRepository _repo;
        public PantherTypeService(IPantherTypeRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<PantherType>> GetAllAsync()
        {
           return await _repo.GetAllAsync();
        }
    }
}
