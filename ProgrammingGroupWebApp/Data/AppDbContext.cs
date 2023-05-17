using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CodingMeetUp> codingMeetUps { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<AddLanguage> addLanguages { get; set; }
    }
}
