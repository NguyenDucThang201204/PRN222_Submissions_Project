using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAL;

namespace BLL
{
    public class PantherProfileService : IPantherProfileService
    {
        private readonly IPantherProfileRepo repo;
        public PantherProfileService(IPantherProfileRepo repo)
        {
            this.repo = repo;
        }
        public void Delete(PantherProfile pantherProfile)
        {
            repo.Delete(pantherProfile.PantherProfileId);
        }

        public List<PantherProfile> GetAll()
        {
            return repo.GetAll();
        }

        public PantherProfile GetById(int pantherProfileId)
        {
            return repo.GetById(pantherProfileId);
        }

        public void Save(PantherProfile pantherProfile)
        {
            repo.Add(pantherProfile);
        }

        public List<PantherProfile> Search(double? weight, string pantherTypeName)
        {
            return repo.Search(weight, pantherTypeName);
        }

        public void Update(PantherProfile pantherProfile)
        {
            repo.Update(pantherProfile);
        }
    }
}
