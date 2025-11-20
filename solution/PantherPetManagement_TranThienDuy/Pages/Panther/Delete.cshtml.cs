using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

namespace PantherPetManagement_TranThienDuy.Pages.Panther
{
    public class DeleteModel : PageModel
    {
        private readonly PantherProfileService _context;

        public DeleteModel(PantherProfileService context)
        {
            _context = context;
        }

        public int roleID { get; set; }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            roleID = HttpContext.Session.GetInt32("RoleId") ?? 0;
            if (roleID != null && roleID != 2)
            {
                return RedirectToPage("/AccessDenied");

            }
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = _context.GetById(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = _context.GetById(id);
            if (pantherprofile != null)
            {
                PantherProfile = pantherprofile;
                _context.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
