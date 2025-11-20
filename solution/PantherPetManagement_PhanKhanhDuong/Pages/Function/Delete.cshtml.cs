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
    public class DeleteModel : PageModel
    {
        private readonly PantherPetManagement.Repository.Models.Su25pantherDbContext _context;

        public DeleteModel(PantherPetManagement.Repository.Models.Su25pantherDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = await _context.PantherProfiles.FindAsync(id);
            if (pantherprofile != null)
            {
                PantherProfile = pantherprofile;
                _context.PantherProfiles.Remove(PantherProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
