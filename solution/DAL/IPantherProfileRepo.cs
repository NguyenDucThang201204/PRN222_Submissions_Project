using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DAL
{
    public interface IPantherProfileRepo
    {
        List<PantherProfile> GetAll();
        PantherProfile? GetById(int id);
        void Add(PantherProfile profile);
        void Update(PantherProfile profile);
        void Delete(int id);
        List<PantherProfile> Search(double? weight, string pantherTypeName);
    }
}
