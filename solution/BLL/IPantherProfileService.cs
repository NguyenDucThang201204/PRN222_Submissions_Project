using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace BLL
{
    public interface IPantherProfileService
    {
        void Save(PantherProfile pantherProfile);
        void Delete(PantherProfile pantherProfile);
        void Update(PantherProfile pantherProfile);
        List<PantherProfile> GetAll();
        PantherProfile GetById(int pantherProfileId);
        List<PantherProfile> Search(double? weight, string pantherTypeName);
    }
}
