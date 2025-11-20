using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using Services;

namespace PantherPetManagement_TranThienDuy.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public PantherAccount Input { get; set; }
        private readonly AccountService _loginService;

        public LoginModel(AccountService loginService)
        {
            _loginService = loginService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var account = _loginService.LoginAccount(Input.Email, Input.Password);
            if (account != null)
            {
                HttpContext.Session.SetInt32("RoleId", account.RoleId);
                return RedirectToPage("/Panther/Index");
            }
            else
            {
                TempData["message"] = "Invalid Email or Password!";
                return Page();
            }
        }
    }
}
