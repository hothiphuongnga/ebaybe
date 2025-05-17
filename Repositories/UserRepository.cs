namespace ebaybe.Repositories;
using ebaybe.Data;
using ebaybe.Models;
using Microsoft.EntityFrameworkCore;

public interface IUserRepository
{
    Task<User?> GetByEmailAndPassword(string email, string password);
}
public class UserRepository : IUserRepository
{
    private readonly DemoApiDbContext _context;

    public UserRepository(DemoApiDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}