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
    public class DetailsModel : BasePageModel
    {
        private readonly IPantherProfileService service;

        public DetailsModel(IPantherProfileService service)
        {
            this.service = service;
        }

        public BusinessObject.PantherProfile PantherProfile { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            var authResult = CheckPermission();
            if (authResult != null)
            {
                return authResult;
            }
            var pantherProfile = service.GetById(id);
            if (pantherProfile == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = pantherProfile;
            }
            return Page();
        }
    }
}
