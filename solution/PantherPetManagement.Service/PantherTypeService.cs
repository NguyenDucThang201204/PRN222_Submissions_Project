using PantherPetManagement.Repository;
using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Service
{
    public class PantherTypeService : IPantherTypeService
    {
        private readonly IPantherTypeRepo _repo;
        public PantherTypeService(IPantherTypeRepo repo)
        {
            _repo = repo;
        }
        public List<PantherType> GetCategories()
        {
            return _repo.GetCategories();
        }
    }
}
