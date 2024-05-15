using Microsoft.EntityFrameworkCore;

namespace BeerSender.Persistence;

public class BeerContext : DbContext
{
    public BeerContext(DbContextOptions options) : base(options)
    { }

    public DbSet<PersistedPackage> BeerPackages { get; set; }
}