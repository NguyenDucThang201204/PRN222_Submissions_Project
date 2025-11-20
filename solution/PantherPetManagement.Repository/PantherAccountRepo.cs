using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Repository
{
    public class PantherAccountRepo : IPantherAccountRepo
    {
        public PantherAccount GetPantherAccountById(int id)
        {
            using var context = new Su25pantherDbContext();
            return context.PantherAccounts.FirstOrDefault(x => x.AccountId.Equals(id));
        }
    }
}
