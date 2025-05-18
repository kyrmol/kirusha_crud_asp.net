using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kirusha_crud_asp.net.Model;

namespace kirusha_crud_asp.net.Data
{
    public class kirusha_crud_aspnetContext : DbContext
    {
        public kirusha_crud_aspnetContext (DbContextOptions<kirusha_crud_aspnetContext> options)
            : base(options)
        {
        }

        public DbSet<kirusha_crud_asp.net.Model.Patient> Patient { get; set; } = default!;
        public DbSet<kirusha_crud_asp.net.Model.Dentist> Dentist { get; set; } = default!;
        public DbSet<kirusha_crud_asp.net.Model.Treatment> Treatment { get; set; } = default!;
    }
}
