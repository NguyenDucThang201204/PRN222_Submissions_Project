using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAL
{
    public interface IAccountRepo
    {
        PantherAccount? GetPantherAccount(string email, string password);
    }
}
