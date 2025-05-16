using Microsoft.EntityFrameworkCore;
using lab2_gym.Models;

namespace lab2_gym.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
