using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAL
{
    public interface IPantherTypeRepo
    {
        List<PantherType> GetPantherTypes();
        PantherType GetPantherTypeById(int id);
    }
}
