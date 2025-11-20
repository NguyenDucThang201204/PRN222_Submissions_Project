using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PantherPetManagement_NguyenThaiDuy.Pages.PantherProfile
{
    public class CreateModel : BasePageModel
    {
        private readonly IPantherProfileService pantherProfileService;
        private readonly IPantherTypeService pantherTypeService;
       

        public CreateModel(IPantherProfileService pantherProfileService, IPantherTypeService pantherTypeService)
        {
            this.pantherTypeService = pantherTypeService;
            this.pantherProfileService = pantherProfileService;
           
        }

        [BindProperty]
        public PantherProfileInput Input { get; set; } = new();

        public SelectList PantherTypes { get; set; } = null!;

        public class PantherProfileInput
        {
            [Required(ErrorMessage = "Panther Name is required")]
            [MinLength(4, ErrorMessage = "Panther Name must be at least 4 characters")]
            public string PantherName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Weight is required")]
            [Range(30.1, double.MaxValue, ErrorMessage = "Weight must be greater than 30")]
            public double Weight { get; set; }

            [Required(ErrorMessage = "Panther Type is required")]
            public int PantherTypeId { get; set; }

            public string Characteristics { get; set; } = string.Empty;
            public string Warning { get; set; } = string.Empty;
        }

        public IActionResult OnGet()
        {
            // kiem tra user co quyen create hay ko
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            LoadPantherTypes();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var authResult = CheckPermission(requireManager: true);
            if (authResult != null) return authResult;

            
            if (!string.IsNullOrEmpty(Input.PantherName))
            {
                // Check for special characters
                if (Regex.IsMatch(Input.PantherName, @"[#@&()]"))
                {
                    ModelState.AddModelError("Input.LionName", "Lion Name cannot contain special characters (#, @, &, (, ))");
                }

                // Check if each word starts with capital letter
                var words = Input.PantherName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!char.IsUpper(word[0]))
                    {
                        ModelState.AddModelError("Input.LionName", "Each word in Lion Name must start with a capital letter");
                        break;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                LoadPantherTypes();
                return Page();
            }

            var pantherProfile = new BusinessObject.PantherProfile
            {
                PantherName = Input.PantherName,
                Weight = Input.Weight,
                PantherTypeId = Input.PantherTypeId,
                Characteristics = Input.Characteristics,
                Warning = Input.Warning,
                ModifiedDate = DateTime.Now
            };

            pantherProfileService.Save(pantherProfile);

           

            return RedirectToPage("./Index");
        }

        private void LoadPantherTypes()
        {
            var pantherTypes = pantherTypeService.GetPantherTypes();
            PantherTypes = new SelectList(pantherTypes, "PantherTypeId", "PantherTypeName");
        }
    }
}
