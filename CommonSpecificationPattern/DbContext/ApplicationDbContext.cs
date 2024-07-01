using Specification.Model;
using Microsoft.EntityFrameworkCore;

namespace Specification.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
     
    }
}
