using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PantherPetManagement.BLL.Services;
using PantherPetManagement.DAL;
using System.Text.RegularExpressions;

namespace PantherPetManagement_TrinhHaiDuc.Pages.PantherProfile
{
    [Authorize(Policy = "Full")]
    public class CreateModel : PageModel
    {
        private readonly IPantherProfileService _service;
        private readonly IPantherTypeService _service2;
        private readonly IHubContext<HubServer> _hubContext;
        public CreateModel(IPantherProfileService service, IPantherTypeService service2, IHubContext<HubServer> hubContext)
        {
            _service = service;
            _service2 = service2;
            _hubContext = hubContext;
        }

        [BindProperty]
        public PantherPetManagement.DAL.PantherProfile Add { get; set; } = new();

        public List<PantherType> ComboBox { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Add.ModifiedDate = DateTime.Now;
            ComboBox = await _service2.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            ComboBox = await _service2.GetAllAsync();

            if (Add.PantherName.Length <= 4)
            {
                ModelState.AddModelError(string.Empty, "PantherName must be greater than 4 characters");
            }
            string[] name = Add.PantherName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in name)
            {
                if (!Regex.IsMatch(word, @"^[A-Z]"))
                {
                    ModelState.AddModelError(string.Empty, "each word in PantherName must begin with capital letter");
                    break;
                }
            }

            if (Regex.IsMatch(Add.PantherName, @"[^A-Za-z0-9\s]"))
            {
                ModelState.AddModelError(string.Empty, "PantherName must not contain special character");
            }

            if (Add.Weight <= 90)
            {
                ModelState.AddModelError(string.Empty, "Weight must be greater than 90");
            }

            DateTime validate = new DateTime(2025, 7, 20);
            if (Add.ModifiedDate >= validate)
            {
                ModelState.AddModelError(string.Empty, "ModifiedDate must be lower than 2025-07-20");
            }

            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _service.AddAsync(Add);
            await _hubContext.Clients.All.SendAsync("Reload", Add.PantherProfileId);
            return RedirectToPage("Index");
        }
    }
}
