using Microsoft.EntityFrameworkCore;
using BudgetTracker.Domain.Entites;

namespace BudgetTracker.Infrastructure.Data;

public class BudgetDbContext : DbContext
{
    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
    {
    }



    public DbSet<Budget> Budgets { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Budget>()
        .HasOne(b => b.Category)
        .WithMany()
        .HasForeignKey(b => b.CategoryId)
        .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

    }
}
