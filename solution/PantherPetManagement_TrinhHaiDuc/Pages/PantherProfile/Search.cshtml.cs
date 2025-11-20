using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PantherPetManagement.BLL.Services;

namespace PantherPetManagement_TrinhHaiDuc.Pages.PantherProfile
{
    [Authorize(Policy = "View")]
    public class SearchModel : PageModel
    {
        private readonly IPantherProfileService _service;
        public SearchModel(IPantherProfileService service)
        {
            _service = service;
        }

        public string Role { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public int TotalPage { get; set; }
        public List<PantherPetManagement.DAL.PantherProfile> Entities { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public double? Search1 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search2 { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var all = await _service.GetAllByOr(Search1, Search2);
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
