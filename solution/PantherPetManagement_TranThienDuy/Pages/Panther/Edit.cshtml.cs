using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

namespace PantherPetManagement_TranThienDuy.Pages.Panther
{
    public class EditModel : PageModel
    {
        private readonly PantherProfileService _context;

        public EditModel(PantherProfileService context)
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

            var pantherprofile =  _context.GetById(id);
            if (pantherprofile == null)
            {
                return NotFound();
            }
            PantherProfile = pantherprofile;
            ViewData["PantherTypeId"] = new SelectList(_context.GetAllClub(), "PantherTypeId", "PantherTypeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(PantherProfile.PantherName)
               || string.IsNullOrEmpty(PantherProfile.Warning)
               || string.IsNullOrEmpty(PantherProfile.Characteristics)
               || string.IsNullOrEmpty(PantherProfile.ModifiedDate.ToString())
               || string.IsNullOrEmpty(PantherProfile.Weight.ToString())

               )
            {
                ModelState.AddModelError(string.Empty, "All fields are required. Please fill in all the information.");
            }
            if (PantherProfile.PantherName.Length < 4)
            {
                ModelState.AddModelError("PantherProfile.PantherName", "Minimum 4 characters.");
            }
            else
            {
                // Mỗi từ phải viết hoa chữ cái đầu, không chứa ký tự đặc biệt #@&()
                var words = PantherProfile.PantherName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word.Length == 0 || !char.IsUpper(word[0]))
                    {
                        ModelState.AddModelError("PantherProfile.PantherName", "Each word start with a capital letter.");
                        break;
                    }
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(PantherProfile.PantherName, "[#@&()]"))
                {
                    ModelState.AddModelError("PantherProfile.PantherName", "No special characters #@&().");
                }
            }
            if (PantherProfile.Weight <= 90)
            {
                ModelState.AddModelError("PantherProfile.Weight", "Weight must be greater than 90.");
            }

            if (!ModelState.IsValid)
            {
                // Repopulate the dropdown list if validation fails
                var types = _context.GetAllClub();
                ViewData["PantherTypeId"] = new SelectList(_context.GetAllClub(), "PantherTypeId", "PantherTypeName");
                return Page();

            }

            try
            {
                _context.Update(PantherProfile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToPage("./Index");
        }

    }
}
