using PantherPetManagement.Repository;
using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Service
{
    public class PantherProfileService : IPantherProfileService
    {
        private readonly IPantherProfileRepo _repo;

        public PantherProfileService(IPantherProfileRepo repo)
        {
            _repo = repo;
        }
        public void DeleteProduct(PantherProfile p)
        {
            _repo.DeletePanther(p);
        }

        public PantherProfile GetProductById(int id)
        {
            return _repo.GetPantherById(id);
        }

        public List<PantherProfile> GetProducts()
        {
            return _repo.GetPanther();
        }

        public void SaveProduct(PantherProfile p)
        {
            _repo.SavePanther(p);
        }

        public void UpdateProduct(PantherProfile p)
        {
            _repo.UpdatePanther(p);
        }
    }
}
