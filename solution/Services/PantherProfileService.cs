using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PantherProfileService
    {
        private readonly PantherProfileRepo _LionRepo;

        public PantherProfileService(PantherProfileRepo LionRepo)
        {
            _LionRepo = LionRepo;
        }
        public List<PantherProfile> GetAll()
            => _LionRepo.GetAll();
        public List<PantherType> GetAllClub()
            => _LionRepo.GetAllClub();
        public async Task<(List<PantherProfile> Items, int TotalCount)> GetPagedWithTypeAsync(int page, int pageSize)
            => await _LionRepo.GetPagedWithTypeAsync(page, pageSize);
        public async Task<List<PantherProfile>> SearchAsync(double? weight, string? lionTypeName)
=> await _LionRepo.SearchAsync(weight, lionTypeName);
        public PantherProfile GetById(int accountId)
            => _LionRepo.GetById(accountId);
        public void Add(PantherProfile account)
            => _LionRepo.Add(account);

        public void Update(PantherProfile account)
            => _LionRepo.Update(account);

        public void Delete(int accountId)
            => _LionRepo.Delete(accountId);
    }
}
