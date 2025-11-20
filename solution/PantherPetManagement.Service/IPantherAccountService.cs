using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Service
{
    public interface IPantherAccountService
    {
        PantherAccount GetAccountById(int id);
    }
}
