using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DAL;

namespace BLL
{
    public class PantherTypeService : IPantherTypeService
    {
        private readonly IPantherTypeRepo _repo;
        public PantherTypeService(IPantherTypeRepo repo)
        {
            _repo = repo;
        }
        public List<PantherType> GetPantherTypes()
        {
            return _repo.GetPantherTypes();
        }
    }
}
