using PantherPetManagement.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace PantherPetManagement_TrinhHaiDuc.Pages.PantherProfile
{
    [Authorize(Policy = "View")]
    public class IndexModel : PageModel
    {
        private readonly IPantherProfileService _service;
        public IndexModel(IPantherProfileService service)
        {
            _service = service;
        }

        public string Role { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPage { get; set; }
        public List<PantherPetManagement.DAL.PantherProfile> Entities { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var all = await _service.GetAllAsync();
            TotalPage = (int)Math.Ceiling((double)all.Count / PageSize);
            PageIndex = Math.Max(1, Math.Min(PageIndex, TotalPage));
            Entities = all
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            return Page();
        }

    }
}
