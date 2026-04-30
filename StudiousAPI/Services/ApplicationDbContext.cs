using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudiousAPI.Models;

namespace StudiousAPI.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<StudySet> FlashCards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        
    }
}
