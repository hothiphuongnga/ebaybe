namespace ebaybe.Repositories;

using ebaybe.Data;
using ebaybe.Models;
using Microsoft.EntityFrameworkCore;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
}
public class ProductRepository : IProductRepository
{
    private readonly DemoApiDbContext _context;

public ProductRepository(DemoApiDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync() =>
        await _context.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products.FindAsync(id);

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
}