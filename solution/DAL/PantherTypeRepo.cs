using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAL
{
    public class PantherTypeRepo : IPantherTypeRepo
    {
        public PantherType GetPantherTypeById(int id)
        {
            var context = new Su25pantherDbContext();
            var cc = context.PantherTypes.Find(id);
            context.Dispose();
            return cc;
        }

        public List<PantherType> GetPantherTypes()
        {
            var context = new Su25pantherDbContext();
            var list = context.PantherTypes.ToList();
            context.Dispose();
            return list;
        }
    }
}
