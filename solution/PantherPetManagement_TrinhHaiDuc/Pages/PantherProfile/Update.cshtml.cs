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
    public class UpdateModel : PageModel
    {
        private readonly IPantherProfileService _service;
        private readonly IPantherTypeService _service2;
        private readonly IHubContext<HubServer> _hubContext;
        public UpdateModel(IPantherProfileService service, IPantherTypeService service2, IHubContext<HubServer> hubContext)
        {
            _service = service;
            _service2 = service2;
            _hubContext = hubContext;
        }

        [BindProperty]
        public PantherPetManagement.DAL.PantherProfile Updating { get; set; } = new();



        public List<PantherType> ComboBox { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {

            Updating = await _service.GetByIdAsync(id);
            ComboBox = await _service2.GetAllAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            ComboBox = await _service2.GetAllAsync();

            if (Updating.PantherName.Length <= 3)
            {
                ModelState.AddModelError(string.Empty, "PantherName must be greater than 3 characters");
            }
            string[] name = Updating.PantherName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in name)
            {
                if (!Regex.IsMatch(word, @"^[A-Z]"))
                {
                    ModelState.AddModelError(string.Empty, "each word in PantherName must begin with capital letter");
                    break;
                }
            }

            if (Regex.IsMatch(Updating.PantherName, @"[^A-Za-z0-9\s]"))
            {
                ModelState.AddModelError(string.Empty, "PantherName must not contain special character");
            }

            if (Updating.Weight <= 30)
            {
                ModelState.AddModelError(string.Empty, "Weight must be greater than 30");
            }
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            await _service.UpdateASync(Updating);
            await _hubContext.Clients.All.SendAsync("Reload", Updating.PantherProfileId);
            return RedirectToPage("Index");
        }
    }
}
