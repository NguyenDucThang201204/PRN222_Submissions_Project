using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PantherProfileRepo : IPantherProfileRepo
    {
        public void Add(PantherProfile profile)
        {
            var context = new Su25pantherDbContext();
            try
            {
                context.Add(profile);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
        public void Delete(int id)
        {
            var context = new Su25pantherDbContext();
            try
            {
                var p = context.PantherProfiles.Find(id);
                context.Remove(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
        public List<PantherProfile> GetAll()
        {
            var context = new Su25pantherDbContext();
            var list = new List<PantherProfile>();
            try
            {
                list = context.PantherProfiles.Include(p => p.PantherType).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
        public PantherProfile? GetById(int id)
        {
            var context = new Su25pantherDbContext();
            try
            {
                return context.PantherProfiles.Include(p => p.PantherType)
                    .FirstOrDefault(p => p.PantherProfileId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
        public List<PantherProfile> Search(double? weight, string pantherTypeName)
        {
            var context = new Su25pantherDbContext();
            var query = context.PantherProfiles.Include(x => x.PantherType).AsQueryable();

            if (weight.HasValue || !string.IsNullOrEmpty(pantherTypeName))
            {
                query = query.Where(x =>
                    (weight.HasValue && x.Weight == weight.Value) ||
                    (!string.IsNullOrEmpty(pantherTypeName) && x.PantherType.PantherTypeName.Contains(pantherTypeName))
                );
            }

            return query.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public void Update(PantherProfile profile)
        {
            var context = new Su25pantherDbContext();
            try
            {
                context.Entry<PantherProfile>(profile).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
