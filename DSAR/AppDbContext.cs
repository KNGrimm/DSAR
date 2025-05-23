using Microsoft.EntityFrameworkCore;
using DSAR.Models; // or wherever your models are

namespace DSAR // ✅ Must match what you're using in your controller
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}