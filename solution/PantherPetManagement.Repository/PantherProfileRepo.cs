using Microsoft.EntityFrameworkCore;
using PantherPetManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement.Repository
{
    public class PantherProfileRepo : IPantherProfileRepo
    {
        public void DeletePanther(PantherProfile p)
        {
            try
            {
                using var context = new Su25pantherDbContext();
                var pl =
                context.PantherProfiles.SingleOrDefault(c => c.PantherProfileId == p.PantherProfileId);
                context.PantherProfiles.Remove(pl);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PantherProfile> GetPanther()
        {
            var listProducts = new List<PantherProfile>();
            try
            {
                using var db = new Su25pantherDbContext();
                listProducts = db.PantherProfiles.Include(f => f.PantherType).ToList();
                //using Microsoft. EntityFramework Core in order to use Include()
            }
            catch (Exception e) { }
            return listProducts;
        }

        public PantherProfile GetPantherById(int id)
        {
            using var db = new Su25pantherDbContext();
            return db.PantherProfiles.FirstOrDefault(c => c.PantherProfileId.Equals(id));
        }

        public void SavePanther(PantherProfile p)
        {
            try
            {
                using var context = new Su25pantherDbContext();
                context.PantherProfiles.Add(p); // Add to Product collection
                context.SaveChanges(); // Update Database
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePanther(PantherProfile p)
        {
            try
            {
                using var context = new Su25pantherDbContext();
                context.Entry<PantherProfile>(p).State
                = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
