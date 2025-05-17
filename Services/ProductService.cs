using eaybe.DTOs;
using ebaybe.Models;
using ebaybe.Repositories;

namespace ebaybe.Services;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task<Product?> GetById(int id);
    Task<Product> Create(ProductDto dto);
}
public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Product>> GetAll() => _repo.GetAllAsync();

    public Task<Product?> GetById(int id) => _repo.GetByIdAsync(id);

    public Task<Product> Create(ProductDto dto)
    {
        var product = new Product { Name = dto.Name, Price = dto.Price };
        return _repo.CreateAsync(product);
    }
}