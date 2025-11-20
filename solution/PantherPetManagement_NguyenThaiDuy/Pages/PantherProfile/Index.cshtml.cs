using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BLL;

namespace PantherPetManagement_NguyenThaiDuy.Pages.PantherProfile
{
    public class IndexModel : BasePageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private const int PageSize = 3;

        public IndexModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        public List<BusinessObject.PantherProfile> PantherProfiles { get; set; } = new List<BusinessObject.PantherProfile>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IActionResult OnGet(int pageNumber = 1, string error = null)
        {
            var authResult = CheckPermission();
            if (authResult != null) return authResult;

            if (!string.IsNullOrEmpty(error))
            {
                ErrorMessage = error;
            }

            CurrentPage = pageNumber;
            var allProfiles = _pantherProfileService.GetAll();

            TotalPages = (int)Math.Ceiling(allProfiles.Count / (double)PageSize);
            PantherProfiles = allProfiles
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return Page();
        }

        // Add logout handler
        public IActionResult OnPostLogout()
        {
            return Logout();
        }
    }
}
