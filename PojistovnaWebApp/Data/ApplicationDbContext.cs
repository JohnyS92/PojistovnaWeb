using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PojistovnaWebApp.Models;

namespace PojistovnaWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {                
        public DbSet<PojisteneOsoby> PojisteneOsoby { get; set; }
        public DbSet<SeznamPojisteni> SeznamPojisteni { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

    }
    }
}