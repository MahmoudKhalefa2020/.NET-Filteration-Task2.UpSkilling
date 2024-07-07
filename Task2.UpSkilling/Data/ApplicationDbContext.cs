using Microsoft.EntityFrameworkCore;
using Task2.UpSkilling.Models;

namespace Task2.UpSkilling.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }

}


