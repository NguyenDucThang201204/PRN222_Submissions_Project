using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL;

namespace PantherPetManagement_NguyenThaiDuy.Pages.PantherProfile
{
    public class SearchModel : BasePageModel
    {
        private readonly IPantherProfileService _pantherProfileService;

        public SearchModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        [BindProperty]
        public double? Weight { get; set; }

        [BindProperty]
        public string PantherTypeName { get; set; }

        public List<BusinessObject.PantherProfile> PantherProfiles { get; set; } = new List<BusinessObject.PantherProfile>();
        public bool HasSearched { get; set; }

        public IActionResult OnGet()
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            return Page();
        }

        public IActionResult OnPost()
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            HasSearched = true;
            PantherProfiles = _pantherProfileService.Search(Weight, PantherTypeName);

            return Page();
        }
    }
}
