using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PantherProfileRepo
    {
        private readonly SU25PantherDBContext _context;

        // Inject the DbContext into the constructor
        public PantherProfileRepo(SU25PantherDBContext context)
        {
            _context = context;
        }


        public List<PantherProfile> GetAll()
        {
            return _context.PantherProfiles.Include(u => u.PantherType).OrderDescending().ToList();
        }


        // sort check ky maybe theo ID cua bang dang lam
        public async Task<(List<PantherProfile> Items, int TotalCount)> GetPagedWithTypeAsync(int page, int pageSize)
        {
            var query = _context.PantherProfiles.Include(l => l.PantherType);

            int totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(l => l.PantherProfileId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        //Search (OR lOGIC) weight and lionTypeName

        public async Task<List<PantherProfile>> SearchAsync(double? weight, string? TypeName)
        {
            using (var context = new SU25PantherDBContext())
            {
                var query = context.PantherProfiles
                    .Include(l => l.PantherType)
                    .AsQueryable();

                if (weight.HasValue || !string.IsNullOrEmpty(TypeName))
                {
                    query = query.Where(l =>
                        (weight.HasValue && l.Weight == weight.Value) ||
                        (!string.IsNullOrEmpty(TypeName) &&
                         l.PantherType.PantherTypeName.Contains(TypeName)));
                }

                return await query.OrderBy(l => l.PantherTypeId).ToListAsync();
            }
        }

        //public async Task<List<CoppaItaliaPlayer>> SearchAndAsync(double? weight, string? lionTypeName)
        //{
        //    using (var context = new Su25lionDbContext()) // Assuming Su25lionDbContext is your DbContext
        //    {
        //        var query = context.LionProfiles // Assuming LionProfiles is your DbSet
        //            .Include(l => l.LionType) // Assuming LionType is related to LionProfiles
        //            .AsQueryable();

        //        // If either search term is provided, apply the filter
        //        // The condition 'weight.HasValue || !string.IsNullOrEmpty(lionTypeName)' remains for efficiency.
        //        // It ensures no filter is applied if both inputs are empty.
        //        if (weight.HasValue || !string.IsNullOrEmpty(lionTypeName))
        //        {
        //            query = query.Where(l =>
        //                // AND logic: Both conditions must be met for a record to be included
        //                (weight.HasValue && l.Weight == weight.Value) && // Condition for weight
        //                (!string.IsNullOrEmpty(lionTypeName) && // Condition for lionTypeName
        //                 l.LionType.LionTypeName.Contains(lionTypeName)));
        //        }

        //        return await query.OrderBy(l => l.LionProfileId).ToListAsync();
        //    }
        //}

        //public async Task<List<CoppaItaliaPlayer>> SearchAsync(double? weightFrom, double? weightTo, string? lionTypeName)
        //{
        //    using (var context = new Su25lionDbContext()) // Assuming Su25lionDbContext is your DbContext
        //    {
        //        var query = context.LionProfiles // Assuming LionProfiles is your DbSet
        //            .Include(l => l.LionType) // Assuming LionType is related to LionProfiles
        //            .AsQueryable();

        //        // Apply filter for Weight range (from and to)
        //        if (weightFrom.HasValue)
        //        {
        //            query = query.Where(l => l.Weight >= weightFrom.Value);
        //        }

        //        if (weightTo.HasValue)
        //        {
        //            query = query.Where(l => l.Weight <= weightTo.Value);
        //        }

        //        // Apply filter for LionTypeName
        //        if (!string.IsNullOrEmpty(lionTypeName))
        //        {
        //            query = query.Where(l => l.LionType != null && l.LionType.LionTypeName.Contains(lionTypeName));
        //        }

        //        // Note: The logic here is an implicit AND.
        //        // If weightFrom, weightTo, AND lionTypeName are provided, all conditions must be met.
        //        // If only weightFrom and lionTypeName are provided, those two conditions must be met.

        //        return await query.OrderBy(l => l.LionProfileId).ToListAsync();
        //    }
        //}
        //public async Task<IList<CoppaItaliaPlayer>> GetPlayersQuery(string? searchFullName, string? searchBirthday)
        //{
        //    var query = _context.CoppaItaliaPlayers.Include(c => c.CoppaItaliaClub).AsQueryable();

        //    if (!string.IsNullOrEmpty(searchFullName))
        //    {
        //        query = query.Where(p => p.FullName != null && p.FullName.Contains(searchFullName));
        //    }

        //    if (!string.IsNullOrEmpty(searchBirthday))
        //    {
        //        query = query.Where(p => p.Birthday.HasValue &&
        //                    EF.Functions.Like(
        //                        EF.Functions.Convert.ToString(p.Birthday.Value, 23),
        //                        $"%{searchBirthday}%"
        //                    ));
        //    }

        //    // IMPORTANT: Execute the query here by calling ToListAsync()
        //    return await query.OrderBy(p => p.CoppaItaliaPlayerId).ToListAsync();
        //}


        public PantherProfile GetById(int accountId)
        {

            return _context.PantherProfiles.Include(u => u.PantherType).FirstOrDefault(a => a.PantherProfileId == accountId);
        }

        public void Add(PantherProfile account)
        {
            _context.PantherProfiles.Add(account);
            _context.SaveChanges();
        }

        public void Update(PantherProfile account)
        {
            _context.PantherProfiles.Update(account);
            _context.SaveChanges();
        }

        public void Delete(int accountId)
        {
            var account = _context.PantherProfiles.FirstOrDefault(a => a.PantherProfileId== accountId);
            if (account != null)
            {
                _context.PantherProfiles.Remove(account);
                _context.SaveChanges();
            }
        }

        ///dung khoa ngoai 
        ///
        public List<PantherType> GetAllClub()
        {
            return _context.PantherTypes.ToList();
        }
    }
}
