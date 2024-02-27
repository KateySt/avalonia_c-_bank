using bank.Models;
using Microsoft.EntityFrameworkCore;
using Transaction = bank.Models.Transaction;

namespace bank.Context;

public class ApplicationContext : DbContext
{
    private string cs = "Host=localhost;Port=5432;Database=bank;Username=root;Password=123456789";
    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<ProductCompany> ProductCompanies { get; set; }
    public DbSet<TransactionProduct> TransactionProducts { get; set; }
    public DbSet<StorageProduct> StorageProducts { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(cs);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StorageProduct>()
            .HasKey(sp => new { sp.ProductId, sp.StorageId });

        modelBuilder.Entity<ProductCompany>()
            .HasKey(pc => new { pc.ProductId, pc.CompanyId });

        modelBuilder.Entity<TransactionProduct>()
            .HasKey(tp => new { tp.TransactionId, tp.ProductId });
    }
}