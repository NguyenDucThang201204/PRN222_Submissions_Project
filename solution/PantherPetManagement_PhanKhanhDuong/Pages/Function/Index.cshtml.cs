using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement.Repository.Models;

namespace PantherPetManagement_PhanKhanhDuong.Pages.Function
{
    public class IndexModel : PageModel
    {
        private readonly PantherPetManagement.Repository.Models.Su25pantherDbContext _context;

        public IndexModel(PantherPetManagement.Repository.Models.Su25pantherDbContext context)
        {
            _context = context;
        }

        public IList<PantherProfile> PantherProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PantherProfile = await _context.PantherProfiles
                .Include(p => p.PantherType).ToListAsync();
        }
    }
}
