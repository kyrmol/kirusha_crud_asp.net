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
    public class IndexModel : PageModel
    {
        private readonly kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext _context;

        public IndexModel(kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        public IList<Dentist> Dentist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Dentist = await _context.Dentist.ToListAsync();
        }
    }
}
