using BudgetTracker.Domain.Entites;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}