using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PantherPetManagement_NguyenThaiDuy.Pages
{
    public class IndexModel : BasePageModel
    {
        public IActionResult OnGet()
        {
            if (!IsLoggedIn)
            {
                return RedirectToPage("/Login");
            }

            return RedirectToPage("/PantherProfile/Index");
        }
    }
}
