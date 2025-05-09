using BudgetTracker.Domain.Entites;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid BudgetId { get; set; }

    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public Budget? Budget { get; set; }
}
