using PantherPetManagement.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PantherPetManagement_TrinhHaiDuc.Pages.PantherProfile
{
    [Authorize(Policy = "View")]
    public class DetailModel : PageModel
    {   
        private readonly IPantherProfileService _service;
        public DetailModel(IPantherProfileService service)
        {
            _service = service;
        }
        public PantherPetManagement.DAL.PantherProfile Detail { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Detail = await _service.GetByIdAsync(id);
            return Page();
        }
    }
}
