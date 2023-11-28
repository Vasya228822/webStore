using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore.Models
{
    public class IdentityUser : DbContext
    {
        public IdentityUser(DbContextOptions<IdentityUser> options)
            : base(options)
        {
        }

        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        
        public DbSet<IsRole> isRole { get; set; }
        
        public DbSet<User> user { get; set; }
    }
}