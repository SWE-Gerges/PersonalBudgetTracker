using BudgetTracker.Domain.Common;

namespace BudgetTracker.Application.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<Result<T>> GetItemById(Guid id, CancellationToken cancellationToken);
    Task<Result<IEnumerable<T>>> GetAllItems();
    Task<Result<T>> AddItem(T item);
    Task<Result<T>> UpdateItem(T item);
    Task<Result<bool>> DeleteItem(Guid id, CancellationToken cancellationToken);
}
