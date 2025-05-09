
namespace BudgetTracker.Domain.Entites;
public class Budget
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public decimal TotalAmount { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Limit { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public User? User { get; set; }
}