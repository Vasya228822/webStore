using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        
        public DbSet<IsRole> isRole { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Order> order { get; set; }
    }
}