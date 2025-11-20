using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PantherPetManagement.BLL.Services;

namespace PantherPetManagement_TrinhHaiDuc.Pages.PantherProfile
{
    [Authorize(Policy = "Full")]
    public class DeleteModel : PageModel
    {
        private readonly IPantherProfileService _service;
        private readonly IHubContext<HubServer> _hubContext;
        public DeleteModel(IPantherProfileService service, IHubContext<HubServer> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }


        [BindProperty]
        public PantherPetManagement.DAL.PantherProfile Delete { get; set; } = new();
        public async Task<IActionResult> OnGet(int id)
        {
            Delete = await _service.GetByIdAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            await _service.DeleteAsync(Delete.PantherProfileId);
            await _hubContext.Clients.All.SendAsync("Reload", Delete.PantherProfileId);
            return RedirectToPage("Index");
        }
    }
}
