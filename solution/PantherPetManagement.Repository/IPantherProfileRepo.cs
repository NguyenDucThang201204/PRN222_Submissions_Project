using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Repository
{
    public interface IPantherProfileRepo
    {

        void SavePanther(PantherProfile p);

        void DeletePanther(PantherProfile p);

        void UpdatePanther(PantherProfile p);

        List<PantherProfile> GetPanther();

        PantherProfile GetPantherById(int id);
    }
}
