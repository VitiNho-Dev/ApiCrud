using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }

    public DbSet<ProductModel> Product { get; set; }
}