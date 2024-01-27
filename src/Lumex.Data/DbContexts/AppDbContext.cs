using Lumex.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lumex.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Input> Inputs { get; set; }
    }
}
