using CodeMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeMasters.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<User> User { get; set; }



    }
}
