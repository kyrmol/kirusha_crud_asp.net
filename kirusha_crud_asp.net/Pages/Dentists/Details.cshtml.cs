using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kirusha_crud_asp.net.Data;
using kirusha_crud_asp.net.Model;

namespace kirusha_crud_asp.net.Pages.Dentists
{
    public class DetailsModel : PageModel
    {
        private readonly kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext _context;

        public DetailsModel(kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        public Dentist Dentist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await _context.Dentist.FirstOrDefaultAsync(m => m.dentist_id == id);
            if (dentist == null)
            {
                return NotFound();
            }
            else
            {
                Dentist = dentist;
            }
            return Page();
        }
    }
}
