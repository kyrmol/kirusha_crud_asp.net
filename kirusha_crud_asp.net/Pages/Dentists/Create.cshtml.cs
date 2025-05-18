using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kirusha_crud_asp.net.Data;
using kirusha_crud_asp.net.Model;

namespace kirusha_crud_asp.net.Pages.Dentists
{
    public class CreateModel : PageModel
    {
        private readonly kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext _context;

        public CreateModel(kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dentist Dentist { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dentist.Add(Dentist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
