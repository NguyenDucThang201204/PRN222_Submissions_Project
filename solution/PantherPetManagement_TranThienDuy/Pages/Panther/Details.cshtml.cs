using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace PantherPetManagement_TranThienDuy.Pages.Panther
{
    public class DetailsModel : PageModel
    {
        private readonly Repositories.SU25PantherDBContext _context;

        public DetailsModel(Repositories.SU25PantherDBContext context)
        {
            _context = context;
        }

        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = await _context.PantherProfiles.FirstOrDefaultAsync(m => m.PantherProfileId == id);
            if (pantherprofile == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = pantherprofile;
            }
            return Page();
        }
    }
}
