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
    public class IndexModel : PageModel
    {
        private readonly PantherProfileService _context;

        public IndexModel(PantherProfileService context)
        {
            _context = context;
        }

        public IList<PantherProfile> PantherProfile { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public double? Weight { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? LionTypeName { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public async Task OnGetAsync(int? pageNumber)
        {
            int pageSize = 3;
            CurrentPage = pageNumber ?? 1;

            // Nếu có điều kiện lọc => gọi Search
            if (Weight.HasValue || !string.IsNullOrWhiteSpace(LionTypeName))
            {
                var searchResult = await _context.SearchAsync(Weight, LionTypeName);
                PantherProfile = searchResult;

                // Không dùng phân trang khi đang search
                TotalPages = 1;
                CurrentPage = 1;
            }
            else
            {
                // Không có lọc => gọi phân trang như cũ
                var (items, totalCount) = await _context.GetPagedWithTypeAsync(CurrentPage, pageSize);
                PantherProfile = items;
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            }
        }
    }
}
