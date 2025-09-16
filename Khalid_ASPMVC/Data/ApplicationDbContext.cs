using Khalid_ASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Khalid_ASPMVC.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employees> Employees { get; set; }


    }
}
