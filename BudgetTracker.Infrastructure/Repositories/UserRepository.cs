using BudgetTracker.Application.Interfaces;
using BudgetTracker.Domain.Common;
using BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Infrastructure.Repositories;

public class UserRepository : IGenericRepo<User>
{
    private readonly BudgetDbContext _context;

    public UserRepository(BudgetDbContext context)
    {
        _context = context;
    }

    public async Task<Result<User>> GetItemById(Guid id, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken);
        return user is null ?
            Result<User>.Failure(Error.NotFound) :
            Result<User>.Success(user);
    }

    public async Task<Result<IEnumerable<User>>> GetAllItems()
    {
        IEnumerable<User> users = await _context.Users.ToListAsync();

        return users.Any() ?
            Result<IEnumerable<User>>.Success(users) :
            Result<IEnumerable<User>>.Failure(Error.NotFound);
    }

    public async Task<Result<User>> AddItem(User item)
    {
        await _context.Users.AddAsync(item);
        await _context.SaveChangesAsync();
        return item is null ?
            Result<User>.Failure(Error.NotFound) :
            Result<User>.Success(item);

    }

    public async Task<Result<User>> UpdateItem(User item)
    {
        _context.Users.Update(item);
        await _context.SaveChangesAsync();
        return item is null ?
            Result<User>.Failure(Error.NotFound) :
            Result<User>.Success(item);
    }

    public async Task<Result<bool>> DeleteItem(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetItemById(id, cancellationToken);
        if (user.Value is null)
        {
            return Result<bool>.Failure(Error.NotFound);
        }

        _context.Users.Remove(user.Value);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);
    }
}

