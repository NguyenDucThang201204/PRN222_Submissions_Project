using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Repository
{
    public class PantherTypeRepo : IPantherTypeRepo
    {
        public List<PantherType> GetCategories()
        {
            var listCategories = new List<PantherType>();
            try
            {
                using var context = new Su25pantherDbContext();
                listCategories = context.PantherTypes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCategories;
        }
    }
}
