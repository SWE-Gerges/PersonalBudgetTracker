using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BudgetTracker.Infrastructure.Data;

public class BudgetDbContextFactory : IDesignTimeDbContextFactory<BudgetDbContext>
{
    public BudgetDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BudgetDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=BudgetTrackerDb;User Id=sa;Password=your_password;TrustServerCertificate=True;");

        return new BudgetDbContext(optionsBuilder.Options);
    }
}