using kirusha_crud_asp.net.Data;
using kirusha_crud_asp.net.Migrations;
using kirusha_crud_asp.net.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kirusha_crud_asp.net.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext _context;

        public IndexModel(kirusha_crud_asp.net.Data.kirusha_crud_aspnetContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment
                .Include(a => a.Patient)
                .Include(x => x.Treatment)
                .Include(x => x.Dentist)
                .ToListAsync();

        }
    }
}
