
namespace BudgetTracker.Domain.Entites;
public class Budget
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}