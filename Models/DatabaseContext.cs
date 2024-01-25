using Microsoft.EntityFrameworkCore;

namespace GunApp.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbSet<Gun> Guns => Set<Gun>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
