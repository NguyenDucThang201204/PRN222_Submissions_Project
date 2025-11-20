using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PantherPetManagement.Repository.Models;
using PantherPetManagement.Service;

namespace PantherPetManagement_PhanKhanhDuong.Pages.Function
{
    public class CreateModel : PageModel
    {
        private readonly Su25pantherDbContext _context;
        private readonly IPantherProfileService _contextProduct;
        private readonly IPantherTypeService _contextCategory;


        public CreateModel(Su25pantherDbContext context, IPantherProfileService contextProduct, IPantherTypeService contextCategory)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PantherTypeId"] = new SelectList(_context.PantherTypes, "PantherTypeId", "PantherTypeId");
            return Page();
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PantherProfiles.Add(PantherProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
