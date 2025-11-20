using PantherPetManagement.BLL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PantherPetManagement_TrinhHaiDuc.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IPantherAccountService _service;
        public LoginModel(IPantherAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        [Required] 
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var account = await _service.Login(Email, Password);
            if (account == null)
            {
                ErrorMessage = "Invalid Email or Password!";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.RoleId.ToString())
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToPage("/PantherProfile/Index");
        }
    }
}
