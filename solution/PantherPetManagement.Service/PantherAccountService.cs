using PantherPetManagement.Repository;
using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Service
{
    public class PantherAccountService : IPantherAccountService
    {
        private readonly IPantherAccountRepo _repo;
        public PantherAccountService(IPantherAccountRepo repo) {
        _repo = repo;
        }
        public PantherAccount GetAccountById(int id)
        {
            return _repo.GetPantherAccountById(id);
        }
    }
}
