using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vize.API.Models;

namespace vize.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }


    }
}
