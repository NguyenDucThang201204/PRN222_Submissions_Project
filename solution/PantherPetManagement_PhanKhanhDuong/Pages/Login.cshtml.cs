using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PantherPetManagement.Repository.Models;
using PantherPetManagement.Service;

namespace PantherPetManagement_PhanKhanhDuong.Pages
{
    public class LoginModel : PageModel
    {
        private IPantherAccountService _accountService; // using Dependency Injection
        public LoginModel(IPantherAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var loginId = HttpContext.Session.GetInt32("Account").ToString();
            if (!string.IsNullOrEmpty(loginId))
            {
                return RedirectToPage("/PantherProfilePage/Index");
            }
            return Page();
        }

        [BindProperty]
        public PantherAccount AccountMember { get; set; } = default!;
        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var loginId = HttpContext.Session.GetInt32("Account").ToString();
            if (!string.IsNullOrEmpty(loginId))
            {
                return RedirectToPage("/PantherProfilePage/Index");
            }

            var memberAccount = _accountService.GetAccountById(AccountMember.AccountId);

            if (memberAccount == null)
            {
                ErrorMessage = "You do not have permission to do this function!";
                ModelState.AddModelError(string.Empty, ErrorMessage);

                return Page();
            }
            else if (memberAccount.RoleId == 2 || memberAccount.RoleId == 2)
            {
                HttpContext.Session.SetInt32("Account", memberAccount.RoleId);
                return RedirectToPage("/PantherProfilePage/Index");
            }
            else
            {
                ErrorMessage = "You do not have permission to do this function!";
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
        }
    }
}
