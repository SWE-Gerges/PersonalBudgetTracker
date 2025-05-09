namespace BudgetTracker.Application.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<T> GetItemById(int id);
    Task<IEnumerable<T>> GetAllItems();
    Task<T> AddItem(T item);
    Task<T> UpdateItem(T item);
    Task<bool> DeleteItem(int id);
}
