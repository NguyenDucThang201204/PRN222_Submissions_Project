using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Service
{
    public interface IPantherProfileService
    {
        void SaveProduct(PantherProfile p);

        void DeleteProduct(PantherProfile p);

        void UpdateProduct(PantherProfile p);

        List<PantherProfile> GetProducts();

        PantherProfile GetProductById(int id);
    }
}
